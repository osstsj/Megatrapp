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

namespace Megatrapp
{
    public partial class frmMain : Form
    {

        ZKHelper zKHelper = new ZKHelper();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonRun_Click(object sender, EventArgs e) {
            try {
                if (zKHelper.ConnectTCP("192.168.0.208", "4370") == 1) {
                    labelStatus.Text = "Conectado!";
                    //ArrayList records = zKHelper.DownloadAttendanceData();
                    List<Employee> employees = zKHelper.GetAllUsersInfo();
                    foreach (var employee in employees) {
                        listBoxUsers.Items.Add("Machine Number " + employee.machineNumber);
                        listBoxUsers.Items.Add("Name " + employee.name);
                        listBoxUsers.Items.Add("Password " + employee.password);
                        listBoxUsers.Items.Add("Employee " + employee.privilege);
                        //listBoxClocks.Items.Add(record);
                        //listBoxClocks.Items.Add("#########");
                    }
                }
            } catch (Exception) {

                throw;
            }
        }
    }
}
