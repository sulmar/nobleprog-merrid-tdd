using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace TestApp.Integrations
{
    // ADO.NET

    public class DbCustomerRepository
    {
        // dotnet add package Microsoft.Data.SqlClient

        private SqlConnection connection;

        public DbCustomerRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Add(Customer customer)
        {
            const string sql = "INSERT INTO dbo.Customers (FirstName, LastName) VALUES (@FirstName, @LastName)";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Customer> GetAll() 
        {
            List<Customer> customers = new List<Customer>();

            const string sql = "SELECT CustomerId, FirstName, LastName FROM dbo.Customers";

            SqlCommand command = new SqlCommand (sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                // Mapowanie rekordu na obiekt
                Customer customer = new Customer();
                customer.Id = reader.GetInt32(0);
                customer.FirstName = reader.GetString(1);
                customer.LastName = reader.GetString(2);    

                customers.Add(customer);
            }

            connection.Close();

            return customers;
        }
    }
}
