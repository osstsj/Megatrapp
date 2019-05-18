using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class EnumHelper {

        public enum InOutMode {
            CheckIn = 0,
            CheckOut = 1,
            BreakOut = 2,
            BreakIn = 3,
            OTIn = 4,
            OTOut = 5,
        }

        public enum VerifyMethod {
            UnSet = -1,
            Password = 0,
            FingerPrint = 1,
            Card = 2,
        }

        public enum UserPrivilege {
            User = 0,
            Enroller = 1,
            Admin = 2,
            Superadmin = 3, //SuperAdmin?
        }

        public enum EventMask {
            OnAttTransaction = 0x01, // also OnAttTransactionEx
            OnFinger = 0x02,
            OnNewUser = 0x04,
            OnEnrollFinger = 0x08,
            OnKeyPress = 0x10,
            OnVerify = 0x100,
            OnFingerFeature = 0x200,
            OnDoorAlarm = 0x400, // OnDoor & OnAlarm
            OnHIDNum = 0x800,
            OnWriteCard = 0x1000,
            OnEmptyCard = 0x2000,
            OnDeleteTemplate = 0x4000,
        }


    }
}
