using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Megatrapp.model;
using System.Windows.Forms;
using System.Collections;

namespace Megatrapp.controller {
    class ZKHelper {

        public zkemkeeper.CZKEMClass serviceController = new zkemkeeper.CZKEMClass();
        public List<Employee> employeeList = new List<Employee>();
        private bool deviceIsConnected = false; //the boolean value identifies whether the device is connected
        private int machineNumber = 1;
        private const string PASSWORD = "";
        private const string PORT = "4370";
        private string enrollNumber;
        private string name;
        private int privilege;
        private bool machineEnable;
        public Action<int> OnVerify;
        public delegate DataGridView GetRealEventDataGridViewHandler();
        private GetRealEventDataGridViewHandler getRealEventDataGridViewHandler;
        private DataGridView gRealEventDataGridView;


        public ZKHelper() {
            OnVerify = serviceController_OnVerify;
        }

        public int ConnectTCP(string ip, DataGridView gRealEventDataGridView) {
            try {
                int dwErrorCore = 0;

                // If parameters are empty
                if (String.IsNullOrEmpty(ip) || String.IsNullOrWhiteSpace(ip)
                || String.IsNullOrEmpty(PORT) || String.IsNullOrWhiteSpace(PORT)) {
                    return -1;
                }

                // If port is out of bounds
                if (Convert.ToInt32(PORT) <= 0 || Convert.ToInt32(PORT) > 65535) {
                    return -1;
                }

                if (deviceIsConnected) {
                    serviceController.Disconnect();
                    // To be implemented
                    //UnregisterRealTime();
                    SetConnectionState(false);
                    return -2;
                }

                if (serviceController.Connect_Net(ip, Convert.ToInt32(PORT))) {
                    SetConnectionState(true);
                    RegisterRealtime();
                    this.gRealEventDataGridView = gRealEventDataGridView;
                    return 1;
                } else {
                    serviceController.GetLastError(ref dwErrorCore);
                    return dwErrorCore;
                }
            } catch (Exception) {
                throw;
            }
        }

        public void SetRealTimeDataGridView(GetRealEventDataGridViewHandler dgcHandler) {
            getRealEventDataGridViewHandler = dgcHandler;
            gRealEventDataGridView = getRealEventDataGridViewHandler();
            
        }

        public List<Employee> GetAllUsersInfo() {
            serviceController.ReadAllUserID(machineNumber);
            ArrayList users = new ArrayList();
            List<Employee> employees = new List<Employee>();
            while (serviceController.SSR_GetAllUserInfo(machineNumber, out enrollNumber, out name, out password, out privilege, out machineEnable)) {
                employees.Add(new Employee(enrollNumber, machineNumber, name, PASSWORD, privilege));
            }
            return employees;
        }

        public List<AttendanceRecord> DownloadAttendanceData() {
            string enrollNumber = "";
            int verifyMode = 0;
            int inOutMode = 0;
            int year = 0;
            int month = 0;
            int day = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;
            int workCode = 0;
            List<AttendanceRecord> records = new List<AttendanceRecord>();
            // should disable the device first
            serviceController.ReadAllGLogData(machineNumber);
            while (serviceController.SSR_GetGeneralLogData(machineNumber, out enrollNumber, out verifyMode,
                    out inOutMode, out year, out month, out day, out hour, out minute, out second, ref workCode)) {
                records.Add(new AttendanceRecord(machineNumber, enrollNumber, verifyMode, inOutMode, year, month, day, hour, minute, second, workCode));
            }
            return records;
        }

        public int RegisterRealtime() {
            if (!GetConnectionState()) {
                MessageBox.Show("No hay conexion con el dispositivo");
                return -1;
            }
            if (serviceController.RegEvent(GetMachineNumber(), 65535)) {
                this.serviceController.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(OnVerify);
                return 1;
            } else {
                return 0;
            }
        }

        public void UnregisterRealTime() {
            this.serviceController.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(OnVerify);
        }

        public virtual void serviceController_OnVerify(int userID) {
            MessageBox.Show("ENTRE!");
            if (userID != -1) {
                gRealEventDataGridView.Rows.Add();
                MessageBox.Show("Verified user " + userID);
            }
        }

        public void Disconnect() {
            if (GetConnectionState()) {
                serviceController.Disconnect();
                // To be implemented
                //UnregisterRealTime();
            }
        }

        public bool GetConnectionState() {
            return deviceIsConnected;
        }

        public void SetConnectionState(bool state) {
            deviceIsConnected = state;
        }

        public int GetMachineNumber() {
            return this.machineNumber;
        }

        public void SetMachineNumber(int machineNumber) {
            this.machineNumber = machineNumber;
        }

    }
}