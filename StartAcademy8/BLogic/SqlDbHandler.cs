using Microsoft.Data.SqlClient;
using StartAcademy8.DataModels;

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
        public void GetEmployeeByEnrollment(string enrollment)
        {
            try
            {
                _command.CommandText = "select * from Employee where Enrollment = @Enrollment";
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
