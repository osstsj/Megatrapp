using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class Payroll {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Payroll(DateTime startDate, DateTime endDate) {
            StartDate = startDate;
            EndDate = endDate;
        }

        public Payroll(int id, DateTime startDate, DateTime endDate) {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
