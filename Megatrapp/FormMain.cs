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

namespace Megatrapp
{    public partial class frmMain : Form
    {

        
        private System.Threading.Timer timer;

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
            } catch (Exception) {

                throw;
            }
            
        }

        private void SomeMethodRunsAt0000() {
            // Send to DB
            EraseRecords();
            DownloadRecords();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            // Download records every 15 minutes or 15,000 miliseconds.
            // 1000 = 1 second
            timerApp.Interval = 1000 * 60 * 15;
            SetUpTimer(new TimeSpan(00, 00, 00));
        }

        private void buttonRun_Click(object sender, EventArgs e) {
            try {
                if (buttonRun.Text == "&Iniciar") {
                    buttonRun.Text = "&Detener";                    
                    timerApp.Enabled = true;
                    DownloadRecords();
                    labelStatus.Text = "Registros descargados";
                } else {
                    buttonRun.Text = "&Iniciar";
                    labelStatus.Text = "Detenido";
                    timerApp.Enabled = false;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void DownloadRecords() {
            try {
                ZKHelper zKHelper = new ZKHelper();
                if (zKHelper.ConnectTCP("192.168.0.208", dataGridViewAttendanceRecords) == 1) {
                    ClearDataGridViewData();
                    // The if is in case the GUI needs to be updated from another thread
                    if (labelStatus.InvokeRequired) {
                        labelStatus.Invoke(new MethodInvoker(() => labelStatus.Text = "Registros descargados"));
                    } else {
                        labelStatus.Text = "Registros descargados";
                    }
                    zKHelper.SetDeviceState(false);
                    List<Employee> employees = zKHelper.GetAllUsersInfo();
                    List<AttendanceRecord> records = zKHelper.DownloadAttendanceData();
                    FillDataGridEmployees(employees);
                    FillDataGridAttendanceRecords(records, employees);
                    zKHelper.SetDeviceState(true);
                    zKHelper.Disconnect();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EraseRecords() {
            try {
                ZKHelper zKHelper = new ZKHelper();
                if (zKHelper.ConnectTCP("192.168.0.208", dataGridViewAttendanceRecords) == 1) {
                    zKHelper.SetDeviceState(false);
                    zKHelper.EraseAttendanceData();
                    zKHelper.SetDeviceState(true);
                    zKHelper.Disconnect();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ClearDataGridViewData() {
            // The if is in case the GUI needs to be updated from another thread
            if (dataGridViewAttendanceRecords.InvokeRequired) {
                dataGridViewAttendanceRecords.Invoke(new MethodInvoker(() => dataGridViewAttendanceRecords.Rows.Clear()));
            } else {
                dataGridViewAttendanceRecords.Rows.Clear();
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
                string hour = record.Hour + ":" + record.Minute;
                string date = record.Day + "/" + record.Month + "/" + record.Year;
                // The if is in case the GUI needs to be updated from another thread
                if (dataGridViewAttendanceRecords.InvokeRequired) {
                    dataGridViewAttendanceRecords.Invoke(new MethodInvoker(() => dataGridViewAttendanceRecords.Rows.Add(employee.EnrollNumber, employee.Name, hour, date, record.InOutMode, record.WorkCode)));
                } else {
                    dataGridViewAttendanceRecords.Rows.Add(employee.EnrollNumber, employee.Name, hour, date, record.InOutMode, record.WorkCode);
                }
            }
        }

        private void timerApp_Tick(object sender, EventArgs e) {
            DownloadRecords();
        }

        private void buttonEraseAttendanceRecords_Click(object sender, EventArgs e) {
            try {
                EraseRecords();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateXMLFromDataGridViewClocks() {
            try {
                string xmlFile = string.Format(@"{0}\model\clocks.xml", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName);
                if (File.Exists(xmlFile)) {
                    MessageBox.Show("Deleteing");
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

        private void buttonAdd_Click(object sender, EventArgs e) {
            if (maskedTextBoxClockIP.MaskCompleted) {
                string ip = maskedTextBoxClockIP.Text;
                dataGridViewClocks.Rows.Add(ip);
                GenerateXMLFromDataGridViewClocks();
            } else {
                errorProviderClocksIP.SetError(maskedTextBoxClockIP, "Introduzca todos los digitos.");
            }
        }

        private void dataGridViewClocks_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
                senderGrid.Rows.RemoveAt(e.RowIndex);
                GenerateXMLFromDataGridViewClocks();
            }
        }
    }
}
