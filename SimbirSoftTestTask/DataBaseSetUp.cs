using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    public class DataBaseSetUp
    {
        private readonly string connectionString;

        public DataBaseSetUp(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task DataBaseSetUpAsync()
        {          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE DATABASE SimbirSoftTestTask;";

                command.Connection = connection;
                await command.ExecuteNonQueryAsync();

                command.CommandText =
                    "USE SimbirSoftTestTask;" +
                    "CREATE TABLE Words_Statistic(" +
                       "id INT NOT NULL PRIMARY KEY IDENTITY(1, 1)," +
                        "Word NVARCHAR(100)," +
                        "Site_Name NVARCHAR(100)" +
                     "); ";
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
