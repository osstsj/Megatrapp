using Megatrapp.helper;
using Megatrapp.model;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.dao {
    class IncidenceDAO : IRepository<Incidence> {

        //const string INSERT_QUERY = "INSERT INTO main_employee(full_name) VALUES(@name)";
        const string INSERT_QUERY = "INSERT INTO main_incidences(date, employee_id, incidence_type_id) VALUES(@date, @employeeId, @incidenceTypeId);";
        

        public int Add(Incidence entity) {
            try {
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(INSERT_QUERY, connection)) {
                        connection.Open();
                        cmd.Parameters.AddWithValue("date", NpgsqlDbType.Date, entity.Date);
                        cmd.Parameters.AddWithValue("employeeId", NpgsqlDbType.Integer, entity.EmployeeID);
                        cmd.Parameters.AddWithValue("incidenceTypeId", NpgsqlDbType.Integer, entity.IncidenceTypeId);
                        cmd.Prepare();
                        return cmd.ExecuteNonQuery();
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

        public int Delete(Incidence entity) {
            throw new NotImplementedException();
        }

        public int Get(Incidence entity) {
            throw new NotImplementedException();
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
                        var register = DateTime.Parse(reader["register"].ToString());
                        records.Add(new AttendanceRecord(idEmployee, register));
                    }
                    connection.Close();
                    return records.Count();
                }

            }
        }

        public List<Incidence> GetAll() {
            throw new NotImplementedException();
        }

        public int Update(Incidence entity) {
            throw new NotImplementedException();
        }
    }
}
