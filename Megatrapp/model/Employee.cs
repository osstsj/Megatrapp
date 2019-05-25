using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.model {
    class Employee {

        public string Id { get; set; }
        public string EmployeeCode { get; set; }
        public int MachineNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Privilege { get; set; }
        public bool FoundInDB { get; set; }

        public Employee() {
        }

        public Employee(string id, string employeeCode, int machineNumber, string name, string password, int privilege, bool foundInDB) : this(id) {
            EmployeeCode = employeeCode;
            MachineNumber = machineNumber;
            Name = name;
            Password = password;
            Privilege = privilege;
            FoundInDB = foundInDB;
        }

        public Employee(string enrollNumber, int machineNumber, string name, string password, int privilege, bool foundInDB) : this(enrollNumber, machineNumber, name, password, privilege) {
            FoundInDB = foundInDB;
        }

        public Employee(string enrollNumber, int machineNumber, string name, string password, int privilege) {
            EmployeeCode = enrollNumber;
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
