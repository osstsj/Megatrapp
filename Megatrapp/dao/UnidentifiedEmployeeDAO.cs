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
    class UnidentifiedEmployeeDAO : IRepository<Employee> {

        const string INSERT_QUERY = "INSERT INTO main_unidentifiedemployee(full_name) VALUES(@name)";
        const string SELECT_QUERY_BY_NAME = "SELECT * FROM public.main_unidentifiedemployee WHERE full_name = @name;";

        public int Add(Employee entity) {
            try {
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(INSERT_QUERY, connection)) {
                        connection.Open();
                        cmd.Parameters.AddWithValue("name", NpgsqlDbType.Varchar, entity.Name);
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
            Console.WriteLine("Couldn't add the employee");
            return -1;
        }

        public int Delete(Employee entity) {
            throw new NotImplementedException();
        }

        public int Get(Employee entity) {
            throw new NotImplementedException();
        }

        public Employee GetUnidentifiedEmployeeByName(string name) {
            Employee employee = new Employee();
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(SELECT_QUERY_BY_NAME, connection)) {
                    connection.Open();
                    cmd.Parameters.AddWithValue("name", NpgsqlDbType.Varchar, name);
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        employee.Name = reader["full_name"].ToString();
                        employee.EnrollNumber = reader["id"].ToString();
                    }
                }
            }
            return employee;
        }

        public List<Employee> GetAll() {
            throw new NotImplementedException();
        }

        public int Update(Employee entity) {
            throw new NotImplementedException();
        }

        public int Get(string query) {
            throw new NotImplementedException();
        }
    }
}
