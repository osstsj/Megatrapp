using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Megatrapp.model;

namespace Megatrapp.controller {
    class ZKHelper {

        public zkemkeeper.CZKEMClass serviceController = new zkemkeeper.CZKEMClass();
        public List<Employee> employeeList = new List<Employee>();
        private bool deviceIsConnected = false; //the boolean value identifies whether the device is connected
        private int machineNumber;
        private int port = 4370;
        private int enrollNumber;
        private string name;
        private string pass;
        private string privilege;
        private bool machineEnable;

        public int ConnectTCP(string ip, string port) {
            try {
                int dwErrorCore = 0;

                // If parameters are empty
                if (String.IsNullOrEmpty(ip) || String.IsNullOrWhiteSpace(ip)
                || String.IsNullOrEmpty(port) || String.IsNullOrWhiteSpace(port)) {
                    return -1;
                }

                // If port is out of bounds
                if (Convert.ToInt32(port) <= 0 || Convert.ToInt32(port) > 65535) {
                    return -1;
                }

                if (deviceIsConnected) {
                    serviceController.Disconnect();
                    // To be implemented
                    //UnregisterRealTime();
                    SetConnectionState(false);
                    return -2;
                }

                if (serviceController.Connect_Net(ip, Convert.ToInt32(port))) {
                    SetConnectionState(true);
                    // To be implemented
                    //RegisterRealtime();
                    return 1;
                } else {
                    serviceController.GetLastError(ref dwErrorCore);
                    return dwErrorCore;
                }
            } catch (Exception) {
                throw;
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

        /*public List<Employee> GetEmployees() {
            if (GetConnectionState() == false) {
                return new List<Employee>();
            }

            try {
                //serviceController.ReadAllUserID();
                while (serviceController.SSR_GetAllUserInfo(machineNumber, ) {

                }

            } catch (Exception) {

                throw;
            }
        }*/

        // To be implemented
        /*public void UnregisterRealTime() {
            this.serviceController.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(serviceController_OnFinger);
            this.serviceController.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(serviceController_OnVerify);
            this.serviceController.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(serviceController_OnAttTransactionEx);
            this.serviceController.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(serviceController_OnFingerFeature);
            this.serviceController.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(serviceController_OnDeleteTemplate);
            this.serviceController.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(serviceController_OnNewUser);
            this.serviceController.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(serviceController_OnHIDNum);
            this.serviceController.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(serviceController_OnAlarm);
            this.serviceController.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(serviceController_OnDoor);
            this.serviceController.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(serviceController_OnEnrollFingerEx);
            this.serviceController.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(serviceController_OnWriteCard);
            this.serviceController.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(serviceController_OnEmptyCard);
            this.serviceController.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(serviceController_OnHIDNum);
            this.serviceController.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(serviceController_OnAttTransaction);
            this.serviceController.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(serviceController_OnKeyPress);
            this.serviceController.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(serviceController_OnEnrollFinger);
        }

        public int RegisterRealtime() {
            if (GetConnectionState() == false) {
                // please connect the device first
                return -1024;
            }

            int ret = 0;

            if (serviceController.RegEvent(GetMachineNumber(), 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            {
                //common interface
                this.serviceController.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(serviceController_OnFinger);
                this.serviceController.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(serviceController_OnVerify);
                this.serviceController.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(serviceController_OnFingerFeature);
                this.serviceController.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(serviceController_OnDeleteTemplate);
                this.serviceController.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(serviceController_OnNewUser);
                this.serviceController.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(serviceController_OnHIDNum);
                this.serviceController.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(serviceController_OnAlarm);
                this.serviceController.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(serviceController_OnDoor);

                //only for color device
                this.serviceController.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(serviceController_OnAttTransactionEx);
                this.serviceController.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(serviceController_OnEnrollFingerEx);

                //only for black&white device
                this.serviceController.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(serviceController_OnAttTransaction);
                this.serviceController.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(serviceController_OnWriteCard);
                this.serviceController.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(serviceController_OnEmptyCard);
                this.serviceController.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(serviceController_OnKeyPress);
                this.serviceController.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(serviceController_OnEnrollFinger);


                ret = 1;
            } else {
                serviceController.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0) {
                    lblOutputInfo.Items.Add("*RegEvent failed,ErrorCode: " + idwErrorCode.ToString());
                } else {
                    lblOutputInfo.Items.Add("*No data from terminal returns!");
                }
            }
            return ret;
        }*/

    }
}