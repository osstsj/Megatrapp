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

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonRun_Click(object sender, EventArgs e) {
            try {
                if (buttonRun.Text == "&Iniciar") {
                    buttonRun.Text = "&Detener";
                    timerApp.Enabled = true;
                } else {
                    buttonRun.Text = "&Iniciar";
                    timerApp.Enabled = false;
                }
                
                /*if (zKHelper.ConnectTCP("192.168.0.208", "4370", dataGridViewAttendanceRecords) == 1) {
                    labelStatus.Text = "Conectado!";
                    //Application.Run();
                    List<Employee> employees = zKHelper.GetAllUsersInfo();
                    List<AttendanceRecord> records = zKHelper.DownloadAttendanceData();
                    foreach (Employee employee in employees) {
                        dataGridViewUsers.Rows.Add(employee.EnrollNumber, employee.Name, employee.Privilege, employee.Password, employee.MachineNumber);
                    }
                    foreach (AttendanceRecord record in records) {
                        Employee employee = employees.Find(employeeX => employeeX.EnrollNumber == record.EnrollNumber);
                        string hour = record.Hour + ":" + record.Minute;
                        string date = record.Day + "/" + record.Month + "/" + record.Year;
                        dataGridViewAttendanceRecords.Rows.Add(employee.EnrollNumber, employee.Name, hour, date, record.InOutMode, record.WorkCode);
                    }

                }*/
            } catch (Exception) {

                throw;
            }
        }

        private void timerApp_Tick(object sender, EventArgs e) {
            labelStatus.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
