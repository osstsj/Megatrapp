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

namespace Megatrapp
{
    public partial class frmMain : Form
    {

        ZKHelper zKHelper = new ZKHelper();
        private static System.Timers.Timer timer;

        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            // Download records every 15 minutes or 15,000 miliseconds.
            // 1000 = 1 second
            timerApp.Interval = 1000 * 60 * 15;
        }

        private void buttonRun_Click(object sender, EventArgs e) {
            try {
                if (buttonRun.Text == "&Iniciar") {
                    buttonRun.Text = "&Detener";
                    labelStatus.Text = "En proceso...";
                    timerApp.Enabled = true;
                    DownloadRecords();
                } else {
                    zKHelper.Disconnect();
                    buttonRun.Text = "&Iniciar";
                    labelStatus.Text = "Detenido";
                    timerApp.Enabled = false;
                }
            } catch (Exception) {

                throw;
            }
        }

        private void DownloadRecords() {
            if (zKHelper.ConnectTCP("192.168.0.208", "4370", dataGridViewAttendanceRecords) == 1) {
                ClearDataGridViewData();
                labelStatus.Text = "En proceso...";
                List<Employee> employees = zKHelper.GetAllUsersInfo();
                List<AttendanceRecord> records = zKHelper.DownloadAttendanceData();
                FillDataGridEmployees(employees);
                FillDataGridAttendanceRecords(records, employees);
                zKHelper.Disconnect();
            }
        }

        private void ClearDataGridViewData() {
            dataGridViewAttendanceRecords.Rows.Clear();
        }

        private void FillDataGridEmployees(List<Employee> employees) {
            foreach (Employee employee in employees) {
                dataGridViewUsers.Rows.Add(employee.EnrollNumber, employee.Name, employee.Privilege, employee.Password, employee.MachineNumber);
            }
        }

        private void FillDataGridAttendanceRecords(List<AttendanceRecord> records, List<Employee> employees) {
            foreach (AttendanceRecord record in records) {
                Employee employee = employees.Find(employeeX => employeeX.EnrollNumber == record.EnrollNumber);
                string hour = record.Hour + ":" + record.Minute;
                string date = record.Day + "/" + record.Month + "/" + record.Year;
                dataGridViewAttendanceRecords.Rows.Add(employee.EnrollNumber, employee.Name, hour, date, record.InOutMode, record.WorkCode);
            }
        }

        private void timerApp_Tick(object sender, EventArgs e) {
            DownloadRecords();
        }
    }
}
