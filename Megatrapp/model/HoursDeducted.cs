using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class HoursDeducted {
        public int Id { get; set; }
        public int HoursToDeduct { get; set; }
        public int EmployeeId { get; set; }
        public int PayrollId { get; set; }

        public HoursDeducted(int hoursToDeduct, int employeeId, int payrollId) {
            HoursToDeduct = hoursToDeduct;
            EmployeeId = employeeId;
            PayrollId = payrollId;
        }

        public HoursDeducted(int id, int hoursToDeduct, int employeeId, int payrollId) {
            Id = id;
            HoursToDeduct = hoursToDeduct;
            EmployeeId = employeeId;
            PayrollId = payrollId;
        }
    }
}
