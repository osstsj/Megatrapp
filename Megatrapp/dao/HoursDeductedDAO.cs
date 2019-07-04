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
    class HoursDeductedDAO : IRepository<HoursDeducted> {

        const string INSERT_QUERY = "INSERT INTO main_hoursdeducted(hours_deducted, employee_id, payroll_id) VALUES(@hoursDeducted, @employeeId, @payrollId);";

        public int Add(HoursDeducted entity) {
            try {
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) {
                    using (var cmd = new NpgsqlCommand(INSERT_QUERY, connection)) {
                        connection.Open();
                        cmd.Parameters.AddWithValue("hoursDeducted", NpgsqlDbType.Smallint, entity.HoursToDeduct);
                        cmd.Parameters.AddWithValue("employeeId", NpgsqlDbType.Integer, entity.EmployeeId);
                        cmd.Parameters.AddWithValue("payrollId", NpgsqlDbType.Integer, entity.PayrollId);
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

        public int Delete(HoursDeducted entity) {
            throw new NotImplementedException();
        }

        public int Get(HoursDeducted entity) {
            throw new NotImplementedException();
        }

        public int Get(string query) {
            throw new NotImplementedException();
        }

        public List<HoursDeducted> GetAll() {
            throw new NotImplementedException();
        }

        public int Update(HoursDeducted entity) {
            throw new NotImplementedException();
        }
    }
}
