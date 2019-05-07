using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class AttendanceRecord {
        public int MachineNumber { get; set; }
        public string EnrollNumber { get; set; }
        public int VerifyMode { get; set; }
        public int InOutMode { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public int WorkCode { get; set; }

        public AttendanceRecord(int machineNumber, string enrollNumber, int verifyMode, int inOutMode, int year, int month, int day, int hour, int minute, int second, int workCode) {
            MachineNumber = machineNumber;
            EnrollNumber = enrollNumber;
            VerifyMode = verifyMode;
            InOutMode = inOutMode;
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            WorkCode = workCode;
        }
    }
}
