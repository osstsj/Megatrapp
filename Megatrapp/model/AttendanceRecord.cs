using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class AttendanceRecord {
        public string EmployeeId { get; set; }
        /*
        public int MachineNumber { get; set; }
        public int VerifyMode { get; set; }
        public int InOutMode { get; set; }
        public int WorkCode { get; set; }
        */
        public DateTime dateTime { get; set; }

        public AttendanceRecord(string enrollNumber, DateTime dateTime) {
            EmployeeId = enrollNumber;
            this.dateTime = dateTime;
        }

    }
}
