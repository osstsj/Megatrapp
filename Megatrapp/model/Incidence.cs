using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class Incidence {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeID { get; set; }
        public int IncidenceTypeId{ get; set; }

        public Incidence() {

        }

        public Incidence(int id, DateTime date, int employeeID, int incidenceTypeId) {
            Id = id;
            Date = date;
            EmployeeID = employeeID;
            IncidenceTypeId = incidenceTypeId;
        }
    }
}
