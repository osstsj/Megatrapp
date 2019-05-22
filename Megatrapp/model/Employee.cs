using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class Employee {

        public string EnrollNumber { get; set; }
        public int MachineNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Privilege { get; set; }

        public Employee() {
        }

        public Employee(string enrollNumber, int machineNumber, string name, string password, int privilege) {
            EnrollNumber = enrollNumber;
            MachineNumber = machineNumber;
            Name = name;
            Password = password;
            Privilege = privilege;
        }

        public Employee(string name) {
            Name = name;
        }

        override
        public string ToString() {
            return Name;
        }
    }
}
