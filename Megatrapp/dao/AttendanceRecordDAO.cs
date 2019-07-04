using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Megatrapp.helper;
using System.Configuration;
using Npgsql;
using Megatrapp.model;
using NpgsqlTypes;
using System.Collections;

namespace Megatrapp.dao {
    class AttendanceRecordDAO : IRepository<AttendanceRecord> {

        // Example insert query
        // INSERT INTO main_employeeaccount(username, email, "password", "passwordSalt", "passwordHashAlgorithm", "passwordReminderToken", "passwordReminderExpiration") VALUES ('eduardoalbertorg', 'passw0rd', 'passw0rd', 'passw0rd', 'passw0rd', 'passw0rd', CURRENT_TIMESTAMP);
        string INSERT_QUERY = "INSERT INTO main_attendancerecord(attendance_record, employee_id) VALUES(@time, @employee_id)";
        string SELECT_ALL_QUERY = "SELECT * FROM public.main_employeeaccount";
        const string GET_RECORDS_FROM_YESTERDAY = "select * from main_attendancerecord where DATE(main_attendancerecord.attendance_record) = (CURRENT_DATE-1) AND main_attendancerecord.employee_id = @id;";

        public int Add(AttendanceRecord entity) {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            int.TryParse(entity.EmployeeId, out int enrollNumber);
            Console.WriteLine("Checking if there are no duplicate attendance records...");
            if (Get(entity) == 0) {
                Console.WriteLine("Preparing to add a new row into main_attendancerecord");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(INSERT_QUERY, connection)) {
                        Console.WriteLine("Connection stablished with db for table main_attendancerecord");
                        connection.Open();
                        Console.WriteLine("Swapping timestamp value with " + entity.dateTime);
                        cmd.Parameters.AddWithValue("time", NpgsqlDbType.Timestamp, entity.dateTime);
                        Console.WriteLine("Swapping id value with " + enrollNumber);
                        cmd.Parameters.AddWithValue("employee_id", NpgsqlDbType.Integer, enrollNumber);
                        cmd.Prepare();
                        int value = cmd.ExecuteNonQuery();
                        Console.WriteLine("Affected rows " + value);
                        connection.Close();
                        return value;
                    }

                }
            }
            return -1;
        }

        public List<AttendanceRecord> GetAll() {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(SELECT_ALL_QUERY, connection)) {
                    connection.Open();
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    List<AttendanceRecord> records = new List<AttendanceRecord>();
                    while (reader.Read()) {
                        var idEmployee = reader["employee_id"].ToString();
                        var attendanceRecord = DateTime.Parse(reader["attendance_record"].ToString());
                        records.Add(new AttendanceRecord(idEmployee, attendanceRecord));
                    }
                    connection.Close();
                    return records;
                }

            }
        }

        public int Delete(AttendanceRecord entity) {
            throw new NotImplementedException();
        }

        public int Get(AttendanceRecord entity) {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            string checkDuplicateQuery = "SELECT * FROM main_attendancerecord WHERE attendance_record = @time AND employee_id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(checkDuplicateQuery, connection)) {
                    connection.Open();
                    int.TryParse(entity.EmployeeId, out int id);
                    cmd.Parameters.AddWithValue("time", NpgsqlDbType.Timestamp, entity.dateTime);
                    cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    List<AttendanceRecord> records = new List<AttendanceRecord>();
                    while (reader.Read()) {
                        var idEmployee = reader["employee_id"].ToString();
                        var attendanceRecord = DateTime.Parse(reader["attendance_record"].ToString());
                        records.Add(new AttendanceRecord(idEmployee, attendanceRecord));
                    }
                    connection.Close();
                    return records.Count();
                }
            }
        }

        public int GetAttendanceRecordsFromYesterday(Employee entity) {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(GET_RECORDS_FROM_YESTERDAY, connection)) {
                    connection.Open();
                    int.TryParse(entity.Id, out int id);
                    cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    List<AttendanceRecord> records = new List<AttendanceRecord>();
                    while (reader.Read()) {
                        var idEmployee = reader["employee_id"].ToString();
                        var attendanceRecord = DateTime.Parse(reader["attendance_record"].ToString());
                        records.Add(new AttendanceRecord(idEmployee, attendanceRecord));
                    }
                    connection.Close();
                    return records.Count();
                }
            }
        }

        public int Get(string query) {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(query, connection)) {
                    connection.Open();
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    List<AttendanceRecord> records = new List<AttendanceRecord>();
                    while (reader.Read()) {
                        var idEmployee = reader["employee_id"].ToString();
                        var attendanceRecord = DateTime.Parse(reader["attendance_record"].ToString());
                        records.Add(new AttendanceRecord(idEmployee, attendanceRecord));
                    }
                    connection.Close();
                    return records.Count();
                }

            }
        }

        public int Update(AttendanceRecord entity) {
            throw new NotImplementedException();
        }
    }
}
