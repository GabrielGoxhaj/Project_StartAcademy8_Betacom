using Microsoft.Data.SqlClient;
using StartAcademy8.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy8.BLogic
{
    public class SqlDbHandler
    {
        private readonly SqlConnection _connection = new();
        private readonly SqlCommand _command = new();
        public bool IsDbOnline = false;
        List<Employee> employees = [];

        public SqlDbHandler(string cnnString)
        {
            try
            {
                _connection = new SqlConnection(cnnString);
                _connection.Open();
                IsDbOnline = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Errore Connessione DB: {ex.Message}");
                throw;
            }
            finally { _connection.Close(); }
        }

        public void GetCompleteEmployees()
        {
            try
            {
                _command.CommandText = "SELECT Employee.*, Workday.*" +
                    "From Employee INNER JOIN" +
                    "Workday ON Employee.Enrollment = Workday.Enrollment";
                _command.Connection = _connection;

                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read()) // read va avanti da solo finchè viene letto tutto nel reader
                {
                    Console.WriteLine($"Matricola: {reader.GetSqlString(0)}");
                    Console.WriteLine($"Nominativo: {reader["FullName"]}");
                    Console.WriteLine("--------------------------------");
                    employees.Add(new Employee()
                    {
                        Enrollment = reader["Enrollment"].ToString(),
                        FullName = reader["FullName"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetTotalEmployees()
        {
            int totalEmployees = 0;
            try
            {
                _command.CommandText = "SELECT COUNT(*) FROM Employee";
                _command.Connection = _connection;

                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                totalEmployees = Convert.ToInt16(_command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { _connection.Close(); }
            return totalEmployees;
        }

        public void GetEmployeeById(string enrollment)
        {
            try
            {
                _command.CommandText = $"SELECT * FROM Employee WHERE Enrollment = @Enrollment";
                _command.Parameters.AddWithValue("@Enrollment", enrollment);
                _command.Connection = _connection;

                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read()) // read va avanti da solo finchè viene letto tutto nel reader
                {
                    Console.WriteLine($"Matricola: {reader.GetSqlString(0)}");
                    Console.WriteLine($"Nominativo: {reader["FullName"]}");
                    Console.WriteLine("--------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { _connection.Close(); }
        }
    }
}
