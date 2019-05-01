using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class Employee {

        public Employee(int machineNumber, string name, string password, int privilege) {
            this.machineNumber = machineNumber;
            this.name = name;
            this.password = password;
            this.privilege = privilege;
        }

        public int machineNumber { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int privilege { get; set; }
    }
}
