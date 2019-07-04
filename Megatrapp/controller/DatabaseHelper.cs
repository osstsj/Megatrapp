using Megatrapp.dao;
using Megatrapp.model;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.controller {
    class DatabaseHelper {

        public DatabaseHelper() {

        }

        public void CreateIncidences() {
            try {
                EmployeeDAO employeeDAO = new EmployeeDAO();
                AttendanceRecordDAO attendanceRecordDAO = new AttendanceRecordDAO();
                List<Employee> employeeList = employeeDAO.GetAll();
                //Console.WriteLine(employeeList);
                Console.WriteLine("#####################################");
                foreach (var employee in employeeList) {
                    Console.WriteLine(employee.Id + " " + employee.Name + " " + employee.EmployeeCode);
                    int.TryParse(employee.Id, out int id);
                    var attendanceRecords = attendanceRecordDAO.GetAttendanceRecordsFromYesterday(employee);
                    int hoursDeducted = 0;
                    Console.WriteLine("Number of records " + attendanceRecords);
                    if (attendanceRecords == 0) {
                        // Means the employee didnt work
                        ApplyIncidence(employee, 6);
                    } else if (attendanceRecords == 1) {
                        // Means the employee forgot to check entrance or exit
                        ApplyIncidence(employee, 5);
                        hoursDeducted = Difference_Between_Earliest_Checkout_And_Shift_Start(id) / 60;
                    } else {
                        int difference_earliest_checkout = Difference_Between_Earliest_Checkout_And_Shift_Start(id);
                        int difference_latest_checkout = Difference_Between_Latest_Checkout_And_Shift_End(id);
                        Console.WriteLine("The difference is " + difference_earliest_checkout);
                        Console.WriteLine("The difference is " + difference_earliest_checkout);
                        DetermineTardyIn(employee, difference_earliest_checkout);
                        DetermineTardyOut(employee, difference_latest_checkout);
                        hoursDeducted = (difference_earliest_checkout / 60) + (difference_latest_checkout / 60);
                    }
                    DeductHoursFromPayroll(employee, hoursDeducted);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeductHoursFromPayroll(Employee employee, int hoursToDeduct) {
            try {
                PayrollDAO payrollDAO = new PayrollDAO();
                HoursDeductedDAO hoursDeductedDAO = new HoursDeductedDAO();
                int idPayroll = payrollDAO.GetCurrentPayroll();
                int.TryParse(employee.Id, out int idEmployee);
                HoursDeducted hoursDeducted = new HoursDeducted(hoursToDeduct, idEmployee, idPayroll);
                hoursDeductedDAO.Add(hoursDeducted);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void ApplyIncidence(Employee employee, int type) {
            try {
                IncidenceDAO incidenceDAO = new IncidenceDAO();
                Incidence incidence = new Incidence();
                int.TryParse(employee.Id, out int id);
                incidence.EmployeeID = id;
                incidence.Date = DateTime.Now.AddDays(-1);
                incidence.IncidenceTypeId = type;
                incidenceDAO.Add(incidence);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private int Difference_Between_Earliest_Checkout_And_Shift_Start(int employeeId) {
            try {
                int differenceInMinutes = 0;
                const string STORED_PROCEDURE_QUERY = "SELECT difference_schedule_and_attendance_shift_start(@id)";
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(STORED_PROCEDURE_QUERY, connection)) {
                        connection.Open();
                        cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, employeeId);
                        cmd.Prepare();
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        List<AttendanceRecord> records = new List<AttendanceRecord>();
                        while (reader.Read()) {
                            var idEmployee = reader["difference_schedule_and_attendance_shift_start"].ToString();
                            int.TryParse(idEmployee, out differenceInMinutes);
                        }
                        connection.Close();
                        return differenceInMinutes;
                    }
                }
            } catch (PostgresException ex) {
                switch (ex.SqlState) {
                    // Duplicated entries
                    case "23505":
                        Console.WriteLine("Duplicated entries, will ignore those entries");
                        break;
                    default:
                        break;
                }
            }
            return -1;
        }

        private int Difference_Between_Latest_Checkout_And_Shift_End(int employeeId) {
            try {
                int differenceInMinutes = 0;
                const string STORED_PROCEDURE_QUERY = "SELECT difference_schedule_and_attendance_shift_end(@id)";
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(STORED_PROCEDURE_QUERY, connection)) {
                        connection.Open();
                        cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, employeeId);
                        cmd.Prepare();
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        List<AttendanceRecord> records = new List<AttendanceRecord>();
                        while (reader.Read()) {
                            var idEmployee = reader["difference_schedule_and_attendance_shift_end"].ToString();
                            int.TryParse(idEmployee, out differenceInMinutes);
                        }
                        connection.Close();
                        return differenceInMinutes;
                    }
                }
            } catch (PostgresException ex) {
                switch (ex.SqlState) {
                    // Duplicated entries
                    case "23505":
                        Console.WriteLine("Duplicated entries, will ignore those entries");
                        break;
                    default:
                        break;
                }
            }
            return -1;
        }

        private void DetermineTardyIn(Employee employee, int difference) {
            int incidenceType = 0;
            if (difference >= 0 ) {
                // Means the employee arrived early or on time
                incidenceType = 1;
            } else if (difference < 0) {
                // Means the employee arrived late, lets see for how long...
                if (difference < 0 && difference >= -10) {
                    // Minor tardy
                    incidenceType = 2;
                } else if (difference < -10 && difference >= -15) {
                    // Major tardy
                    incidenceType = 3;
                }
            }
            ApplyIncidence(employee, incidenceType);
        }

        private void DetermineTardyOut(Employee employee, int difference) {
            try {
                int incidenceType = 0;
                if (difference >= 16) {
                    // Means the employee left early
                    incidenceType = 4;
                }
                ApplyIncidence(employee, incidenceType);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
