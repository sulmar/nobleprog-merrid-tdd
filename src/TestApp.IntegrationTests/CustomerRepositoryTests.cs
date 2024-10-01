using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using TestApp.Integrations;
using Testcontainers.MsSql;

namespace TestApp.IntegrationTests
{

    public class CustomerRepositoryTests : IAsyncLifetime
    {
        private MsSqlContainer sqlserver = new MsSqlBuilder()
           // .WithImage("mcr.microsoft.com/mssql/server")
            .WithPassword("yourStrong(!)Password")
            .WithName("test-sql-server-2")
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithPortBinding(1433, 1433)
            .Build();

        public async Task InitializeAsync()
        {
            await sqlserver.StartAsync();

            const string scriptContent = "CREATE DATABASE TestDb GO USE TestDb GO CREATE TABLE dbo.Customers (CustomerId int IDENTITY(1,1) PRIMARY KEY, FirstName nvarchar(100), LastName nvarchar(100)) GO";

            var execResult = await sqlserver.ExecScriptAsync(scriptContent)
                .ConfigureAwait(true);
        }

        public Task DisposeAsync()
        {
            return sqlserver.DisposeAsync().AsTask();
        }

        [Fact]
        public void ConnectionStateReturnsOpen()
        {
            // Given
            using DbConnection connection = new SqlConnection(sqlserver.GetConnectionString());

            // When
            connection.Open();

            // Then
            Assert.Equal(ConnectionState.Open, connection.State);
        }

        [Fact]
        public void Add_TwoCustomers_ShouldReturnTwoCustomers()
        {
            // dotnet add package Testcontainers.MsSql


            // Arrange
            var connectionstring = sqlserver.GetConnectionString();

            SqlConnection connection = new SqlConnection(connectionstring);
            DbCustomerRepository repository = new DbCustomerRepository(connection);

            // Act
            repository.Add(new Customer { FirstName = "a", LastName = "b" });
            repository.Add(new Customer { FirstName = "c", LastName = "d" });

            var customers = repository.GetAll();

            // Assert
            Assert.Equal(2, customers.Count);
        }




    }
}