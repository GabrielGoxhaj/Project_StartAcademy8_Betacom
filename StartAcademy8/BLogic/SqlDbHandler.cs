using Microsoft.Data.SqlClient;
using StartAcademy8.DataModels;
using System.Data;

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
            }
            finally { _connection.Close(); }
        }
        public void GetCompleteEmployees()
        {

            try
            {
                _command.CommandText = "SELECT Employee.*, Workday.* " +
                    "FROM Employee INNER JOIN " +
                    "Workday ON Employee.Enrollment = Workday.Enrollment";
                _command.Connection = _connection;

                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {

                    Console.WriteLine($"Matricola: {reader.GetSqlString(0)}");
                    Console.WriteLine($"Nominativo: {reader["FullName"]}");
                    Console.WriteLine("--------------------------------------------------");

                    employees.Add(new Employee()
                    {
                        Enrollment = reader["Enrollment"].ToString(),
                        FullName = reader["FullName"].ToString()
                    });

                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public string GetEmployeeDepartByEnrollment(string enrollment)
        {
            string dpt = string.Empty;
            try
            {
                using(SqlConnection connection = _connection)
                {
                    connection.Open();
                    _command.CommandText = "exec spGetEmployeeDepartment";
                    _command.Connection = connection;
                    _command.CommandType = System.Data.CommandType.StoredProcedure;

                    _command.Parameters.AddWithValue("@Enrollment", enrollment);

                    _command.Parameters.Add(
                        new SqlParameter("@Department", System.Data.SqlDbType.VarChar, 50).Direction = 
                        System.Data.ParameterDirection.Output);

                    _command.ExecuteNonQuery();
                    dpt = _command.Parameters["@Department"].Value.ToString();
                }
                Console.WriteLine($"Reparto del dipendente con matricola {enrollment}: {dpt}");
            }
            catch (Exception)
            {
                throw;
            }

            return dpt;
        }

        public bool spInsertEmployee(Employee employee)
        {
            bool rsult = false;
            int spValue = 0;
            try
            {
                using (SqlConnection connection = _connection)
                {
                    connection.Open();

                    _command.CommandText = "spInsertPartialEmployee";
                    _command.Connection = connection;
                    _command.CommandType = CommandType.StoredProcedure;

                    _command.Parameters.AddWithValue("@Enrollment", employee.Enrollment);
                    _command.Parameters.AddWithValue("@FullName", employee.FullName);
                    _command.Parameters.AddWithValue("@Role", employee.Role);
                    _command.Parameters.AddWithValue("@Department", employee.Department);
                    _command.Parameters.AddWithValue("@Age", employee.Age);

                    spValue = Convert.ToInt16(_command.ExecuteScalar());
                }

                rsult = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ATTENZIONE! Errore imprevisto: {ex.Message}");
            }

            return rsult;
        }

        public void GetEmployeeByEnrollment(string enrollment)
        {
            try
            {
                _command.CommandText = "SELECT * FROM Employee WHERE Enrollment = @Enrollment";
                _command.Parameters.AddWithValue("@Enrollment", enrollment);

                _command.Connection = _connection;

                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Matricola: {reader.GetSqlString(0)}");
                    Console.WriteLine($"Nominativo: {reader["FullName"]}");
                    Console.WriteLine("--------------------------------------------------");
                }

                reader.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                _connection.Close();
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
    }
}
