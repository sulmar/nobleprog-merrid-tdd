using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using TestApp.Integrations;
using Testcontainers.MsSql;

namespace TestApp.IntegrationTests
{
    // Przyk³ad testów integracyjnych z u¿yciem Docker za pomoc¹ biblioteki Testcontainers
    public class CustomerRepositoryTests : IAsyncLifetime
    {
        private MsSqlContainer sqlserver = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server")
            .WithPassword("yourStrong(!)Password")
            .WithName("test-sql-server")
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithPortBinding(1433, 1433)
            .Build();

        public async Task InitializeAsync()
        {
            await sqlserver.StartAsync();

            string scriptContent = File.ReadAllText("create-database-script.sql");

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

            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionstring)
            {
                InitialCatalog = "TestDb"
            };

            SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
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