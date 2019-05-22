using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Megatrapp.helper;
using Megatrapp.model;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace Megatrapp.dao {
    class UnidentifiedAttendanceRecordDAO : IRepository<AttendanceRecord> {

        string INSERT_QUERY = "INSERT INTO main_unidentifiedattendancerecord(attendance_record, unidentified_employee_id) VALUES(@time, @employee_id)";

        public int Add(AttendanceRecord entity) {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            int.TryParse(entity.EnrollNumber, out int enrollNumber);
            Console.WriteLine("Checking if there are no duplicate attendance records...");
            if (Get(entity) == 0) {
                Console.WriteLine("Preparing to add a new row into main_attendancerecord");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(INSERT_QUERY, connection)) {
                        Console.WriteLine("Connection stablished with db for table main_unidentifiedattendancerecord");
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

        public int Delete(AttendanceRecord entity) {
            throw new NotImplementedException();
        }

        public int Get(AttendanceRecord entity) {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            string checkDuplicateQuery = "SELECT * FROM main_unidentifiedattendancerecord WHERE attendance_record = @time AND unidentified_employee_id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(checkDuplicateQuery, connection)) {
                    connection.Open();
                    int.TryParse(entity.EnrollNumber, out int enrollNumber);
                    cmd.Parameters.AddWithValue("time", NpgsqlDbType.Timestamp, entity.dateTime);
                    cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, enrollNumber);
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    List<AttendanceRecord> records = new List<AttendanceRecord>();
                    while (reader.Read()) {
                        var idEmployee = reader["unidentified_employee_id"].ToString();
                        var register = DateTime.Parse(reader["attendance_record"].ToString());
                        records.Add(new AttendanceRecord(idEmployee, register));
                    }
                    connection.Close();
                    return records.Count();
                }
            }
        }

        public int Get(string query) {
            throw new NotImplementedException();
        }

        public List<AttendanceRecord> GetAll() {
            throw new NotImplementedException();
        }

        public int Update(AttendanceRecord entity) {
            throw new NotImplementedException();
        }
    }
}
