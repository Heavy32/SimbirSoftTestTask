using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataBaseProvider
{
    public class StatisticRepository : IAddStatistic
    {
        private readonly string connectionString;

        public StatisticRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task AddStatisticAsync(IDictionary<string, int> statistic, string siteName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sqlExpression = "USE SimbirSoftTestTask; INSERT INTO Words_Statistic (Word, Site_Name) VALUES (@word, @siteName)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                command.Transaction = transaction;

                try
                {
                    var p1 = new SqlParameter { ParameterName = "@word" };
                    var p2 = new SqlParameter { ParameterName = "@siteName" };
                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    foreach (var item in statistic)
                    {
                        command.Parameters[0].Value = item.Key;
                        command.Parameters[1].Value = siteName; 

                        for (int i = 0; i < item.Value; i++)
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }              
            }
        }
    }
}
