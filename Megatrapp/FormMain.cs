using Megatrapp.controller;
using Megatrapp.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Xml;
using System.IO;
using System.Net;
using System.Configuration;
using Megatrapp.dao;
using Megatrapp.helper;

namespace Megatrapp
{    public partial class frmMain : Form {

        private System.Threading.Timer timer;
        private List<string> clocksList;
        private string originalEmployeeName;

        public frmMain() {
            InitializeComponent();
        }

        private void SetUpTimer(TimeSpan alertTime) {
            try {
                DateTime current = DateTime.Now;
                TimeSpan timeToGo = alertTime - current.TimeOfDay;
                if (timeToGo < TimeSpan.Zero) {
                    return;//time already passed
                }
                this.timer = new System.Threading.Timer(x => {
                    this.SomeMethodRunsAt0000();
                }, null, timeToGo, Timeout.InfiniteTimeSpan);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SomeMethodRunsAt0000() {
            // Checks if there are registered clocks
            if (clocksList.Count > 0) {
                // Send to DB
                EraseRecords();
                BackUpAttendanceAndEmployees();
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            // Download records every 15 minutes or 15,000 miliseconds.
            // 1000 = 1 second
            timerApp.Interval = 1000 * 60 * 15;
            SetUpTimer(new TimeSpan(00, 00, 00));

            clocksList = new List<string>();
            GetClocksFromXMLFile();
            foreach (var clockIP in clocksList) {
                if (!String.IsNullOrEmpty(clockIP) && !String.IsNullOrWhiteSpace(clockIP)) {
                    AddClockToDataGridView(clockIP);
                }
            }
        }

        private void GetClocksFromXMLFile() {
            string xmlFile = string.Format(@"{0}\model\clocks.xml", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName);
            if (File.Exists(xmlFile)) {
                using (XmlReader reader = XmlReader.Create(xmlFile)) {
                    while (reader.Read()) {
                        if (reader.IsStartElement()) {
                            switch (reader.Name.ToString()) {
                                case "ip":
                                    clocksList.Add(reader.ReadString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void buttonRun_Click(object sender, EventArgs e) {
            try {
                labelStatus.Text = "Obteniendo registros";
                BackUpAttendanceAndEmployees();
                labelStatus.Text = "Registros descargados";
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void UploadAttendanceRecordsToDatabase(List<AttendanceRecord> recordList, List<Employee> employeeList) {
            try {
                AttendanceRecordDAO attendanceRecordDAO = new AttendanceRecordDAO();
                EmployeeDAO employeeDAO = new EmployeeDAO();
                UnidentifiedEmployeeDAO unidentifiedEmployeeDAO = new UnidentifiedEmployeeDAO();
                UnidentifiedAttendanceRecordDAO unidentifiedAttendanceRecordDAO = new UnidentifiedAttendanceRecordDAO();
                foreach (AttendanceRecord record in recordList) {
                    bool wasUnidentified = false;
                    string name = "";
                    // Iterate through the employees to find the matching internal enrollNumber for each machine
                    // once it finds the match it saves it to the DB and stores some data for later use
                    foreach (Employee employee in employeeList) {
                        if (string.IsNullOrEmpty(employee.Name)) {
                            Console.WriteLine("Ignoring users without name");
                        } else {
                            // If found a match between the employee and attendance record in the device
                            if (employee.EnrollNumber == record.EnrollNumber) {
                                // If employee exists skip, else insert it into unidentified employees
                                // Check in the DB for the employee's information
                                if (string.IsNullOrEmpty(employeeDAO.GetEmployeeByName(employee.Name).Name)) {
                                    wasUnidentified = true;
                                    Console.WriteLine("Add unidentified employee resulted in: " + unidentifiedEmployeeDAO.Add(employee));
                                } else {
                                    wasUnidentified = false;
                                }
                                name = employee.Name;
                                // Remove the employee list so the next iteration runs faster
                                employeeList.Remove(employee);
                                // if the employee was NOT identified, get the unidentified id and save it
                                if (wasUnidentified) {
                                    Console.WriteLine("Storing UNidentified record");
                                    Employee unidentifiedEmployee = unidentifiedEmployeeDAO.GetUnidentifiedEmployeeByName(name);
                                    record.EnrollNumber = unidentifiedEmployee.EnrollNumber;
                                    unidentifiedAttendanceRecordDAO.Add(record);
                                } else {
                                    // if the employee was identified obtain it's id from the actual DB (not the clock machine)
                                    // and save the attendance record
                                    Console.WriteLine("Storing identified record");
                                    Employee identifiedEmployee = employeeDAO.GetEmployeeByName(name);
                                    record.EnrollNumber = identifiedEmployee.EnrollNumber;
                                    attendanceRecordDAO.Add(record);
                                }
                                Console.WriteLine("Succesfully stored the attendance record");
                                break;
                            }
                        }
                    }   
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshDGVEmployees(List<Employee> employeeList) {
            ClearDataGridViewUsers();
            FillDataGridEmployees(employeeList);
        }

        private void BackUpAttendanceAndEmployees() {
            try {
                foreach (string clockIP in clocksList) {
                    ZKHelper zKHelper = new ZKHelper();
                    if (zKHelper.ConnectTCP(clockIP, dataGridViewAttendanceRecords) == 1) {
                        ClearDataGridViewAttendanceRecords();
                        // Device needs to be disabled first
                        zKHelper.SetDeviceState(false);
                        List<Employee> employees = zKHelper.GetAllUsersInfo();
                        List<AttendanceRecord> records = zKHelper.DownloadAttendanceData();
                        RefreshDGVEmployees(employees);
                        FillDataGridAttendanceRecords(records, employees);
                        zKHelper.SetDeviceState(true);
                        zKHelper.Disconnect();
                        UploadAttendanceRecordsToDatabase(records, employees);
                        // The if is in case the GUI needs to be updated from another thread
                        if (labelStatus.InvokeRequired) {
                            labelStatus.Invoke(new MethodInvoker(() => labelStatus.Text = "Registros descargados"));
                        } else {
                            labelStatus.Text = "Registros descargados";
                        }
                    } else {
                        MessageBox.Show("No hubo conexion con el dispositivo " + clockIP);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EraseRecords() {
            try {
                foreach (var clockIP in clocksList) {
                    ZKHelper zKHelper = new ZKHelper();
                    if (zKHelper.ConnectTCP(clockIP, dataGridViewAttendanceRecords) == 1) {
                        zKHelper.SetDeviceState(false);
                        zKHelper.EraseAttendanceData();
                        zKHelper.SetDeviceState(true);
                        zKHelper.Disconnect();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }   
        }

        private void UpdateUserInfoInAllClocks(Employee modifiedEmployee) {
            try {
                foreach (var clockIP in clocksList) {
                    ZKHelper zKHelper = new ZKHelper();
                    if (zKHelper.ConnectTCP(clockIP, dataGridViewAttendanceRecords) == 1) {
                        zKHelper.SetDeviceState(false);
                        Console.WriteLine("User updated return value: " + zKHelper.UpdateUserInfo(modifiedEmployee));
                        zKHelper.SetDeviceState(true);
                        zKHelper.Disconnect();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearDataGridViewAttendanceRecords() {
            // The if is in case the GUI needs to be updated from another thread
            if (dataGridViewAttendanceRecords.InvokeRequired) {
                dataGridViewAttendanceRecords.Invoke(new MethodInvoker(() => dataGridViewAttendanceRecords.Rows.Clear()));
            } else {
                dataGridViewAttendanceRecords.Rows.Clear();
            }            
        }

        private void ClearDataGridViewUsers() {
            // The if is in case the GUI needs to be updated from another thread
            if (dataGridViewUsers.InvokeRequired) {
                dataGridViewUsers.Invoke(new MethodInvoker(() => dataGridViewUsers.Rows.Clear()));
            } else {
                dataGridViewUsers.Rows.Clear();
            }
        }

        private void FillDataGridEmployees(List<Employee> employees) {
            foreach (Employee employee in employees) {
                // The if is in case the GUI needs to be updated from another thread
                if (dataGridViewUsers.InvokeRequired) {
                    dataGridViewUsers.Invoke(new MethodInvoker(() => dataGridViewUsers.Rows.Add(employee.EnrollNumber, employee.Name, employee.Privilege, employee.Password, employee.MachineNumber)));
                } else {
                    dataGridViewUsers.Rows.Add(employee.EnrollNumber, employee.Name, employee.Privilege, employee.Password, employee.MachineNumber);
                }
            }
        }

        private void FillDataGridAttendanceRecords(List<AttendanceRecord> records, List<Employee> employees) {
            foreach (AttendanceRecord record in records) {
                Employee employee = employees.Find(employeeX => employeeX.EnrollNumber == record.EnrollNumber);
                // The if is in case the GUI needs to be updated from another thread
                if (dataGridViewAttendanceRecords.InvokeRequired) {
                    dataGridViewAttendanceRecords.Invoke(new MethodInvoker(() => dataGridViewAttendanceRecords.Rows.Add(employee.EnrollNumber, employee.Name, record.dateTime)));
                } else {
                    dataGridViewAttendanceRecords.Rows.Add(employee.EnrollNumber, employee.Name, record.dateTime);
                }
            }
        }

        private void timerApp_Tick(object sender, EventArgs e) {
            BackUpAttendanceAndEmployees();
        }

        private void buttonEraseAttendanceRecords_Click(object sender, EventArgs e) {
            try {
                DialogResult result = MessageBox.Show("Seguro que deseas borrar los registros?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) {
                    EraseRecords();
                    labelStatus.Text = "Registros borrados";
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateXMLFromDataGridViewClocks() {
            try {
                string xmlFile = string.Format(@"{0}\model\clocks.xml", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName);
                if (File.Exists(xmlFile)) {
                    File.Delete(xmlFile);
                }
                using (XmlWriter writer = XmlWriter.Create(xmlFile)) {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("clocks");
                    foreach (DataGridViewRow clock in dataGridViewClocks.Rows) {
                        writer.WriteStartElement("clock");
                        writer.WriteElementString("ip", clock.Cells["clocksIP"].Value.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddClockToDataGridView(string ip) {
            dataGridViewClocks.Rows.Add(ip);
        }

        private bool ValidateClockIPIsUnique(string ip) {
            try {
                foreach (DataGridViewRow clock in dataGridViewClocks.Rows) {
                    if (clock.Cells["clocksIP"].Value.ToString() == ip) {
                        return false;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private int CountDotsInString(string source) {
            int count = 0;
            foreach (char c in source)
                if (c == '.') count++;
            return count;
        }

        private bool ValidateNewClockIP() {
            try {
                string ip = textBoxNewClockIP.Text;
                if (ip.Length < 9) {
                    MessageBox.Show("Cuenta con menos de 9 caracteres.");
                    return false;
                }
                if (CountDotsInString(ip) != 3) {
                    MessageBox.Show("Tiene menos de 4 bytes.");
                    return false;
                }
                if (ip.Any(Char.IsWhiteSpace)) {
                    MessageBox.Show("Contiene un espacio dentro de la cadena.");
                    return false;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            // 192.168. 5.2.3
            Console.WriteLine(textBoxNewClockIP.Text);
            if (ValidateNewClockIP()) {
                IPAddress ipAddress;
                if (IPAddress.TryParse(textBoxNewClockIP.Text, out ipAddress)) {
                    string ip = ipAddress.ToString();
                    if (ValidateClockIPIsUnique(ip)) {
                        AddClockToDataGridView(ip);
                        GenerateXMLFromDataGridViewClocks();
                        textBoxNewClockIP.Clear();
                    } else {
                        MessageBox.Show("La IP introducida ya existe en los registros.");
                    } 
                } else {
                    errorProviderClocksIP.SetError(textBoxNewClockIP, "Introduzca un formato de IPv4 válido.");
                }
            } else {
                errorProviderClocksIP.SetError(textBoxNewClockIP, "Introduzca un formato de IPv4 válido.");
            }
        }

        private void dataGridViewClocks_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
                senderGrid.Rows.RemoveAt(e.RowIndex);
                GenerateXMLFromDataGridViewClocks();
            }
        }

        private void textBoxNewClockIP_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                errorProviderClocksIP.Clear();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            DataGridView senderGrid = (DataGridView)sender;
            string employeeId = senderGrid["enrollNumber", e.RowIndex].Value.ToString();
            string alertText = "Desear modificar el usuario " + employeeId + "?";
            DialogResult result = MessageBox.Show(alertText, "Modificacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK) {
                int.TryParse(senderGrid["machineNumberColumn", e.RowIndex].Value.ToString(), out int machineNumber);
                string employeeName = senderGrid["nameColumn", e.RowIndex].Value.ToString().ToUpper();
                string password = senderGrid["passwordColumn", e.RowIndex].Value.ToString();
                int.TryParse(senderGrid["privilegeColumn", e.RowIndex].Value.ToString(), out int privilege);
                Employee modifiedEmployee = new Employee(employeeId, machineNumber, employeeName, password, privilege);
                UpdateUserInfoInAllClocks(modifiedEmployee);
                senderGrid["nameColumn", e.RowIndex].Value = senderGrid["nameColumn", e.RowIndex].Value.ToString().ToUpper();
            } else {
                senderGrid.CancelEdit();
                senderGrid["nameColumn", e.RowIndex].Value = originalEmployeeName;
            }
        }

        private void dataGridViewUsers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            DataGridView senderGrid = (DataGridView)sender;
            originalEmployeeName = senderGrid["nameColumn", e.RowIndex].Value.ToString();
        }
    }
}
