using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class AttendanceRecord {
        public string EnrollNumber { get; set; }
        /*
        public int MachineNumber { get; set; }
        public int VerifyMode { get; set; }
        public int InOutMode { get; set; }
        public int WorkCode { get; set; }
        */
        public DateTime dateTime { get; set; }

        public AttendanceRecord(string enrollNumber, DateTime dateTime) {
            EnrollNumber = enrollNumber;
            this.dateTime = dateTime;
        }

    }
}
