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
    class PayrollDAO : IRepository<Payroll> {

        const string INSERT_QUERY = "INSERT INTO main_payroll(start_date, end_date) VALUES(@startDate, @endDate);";
        const string GET_CURRENT_PAYROLL = "SELECT get_current_payroll();";

        public int Add(Payroll entity) {
            try {
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(INSERT_QUERY, connection)) {
                        connection.Open();
                        cmd.Parameters.AddWithValue("startDate", NpgsqlDbType.Date, entity.StartDate);
                        cmd.Parameters.AddWithValue("endDate", NpgsqlDbType.Date, entity.EndDate);
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

        public int Delete(Payroll entity) {
            throw new NotImplementedException();
        }

        public int Get(Payroll entity) {
            throw new NotImplementedException();
        }

        public int GetCurrentPayroll() {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
            int id = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                using (var cmd = new NpgsqlCommand(GET_CURRENT_PAYROLL, connection)) {
                    connection.Open();
                    cmd.Prepare();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        int.TryParse(reader["get_current_payroll"].ToString(), out id);
                    }
                    connection.Close();
                    return id;
                }
            }
        }

        public int Get(string query) {
            throw new NotImplementedException();
        }

        public List<Payroll> GetAll() {
            throw new NotImplementedException();
        }

        public int Update(Payroll entity) {
            throw new NotImplementedException();
        }
    }
}
