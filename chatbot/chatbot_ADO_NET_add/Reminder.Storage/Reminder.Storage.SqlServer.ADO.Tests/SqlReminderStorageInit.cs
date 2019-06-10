using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.SqlServer.ADO.Tests.Properties;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    public class SqlReminderStorageInit
    {
        private readonly string _connectionString; 

        public SqlReminderStorageInit(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InitalizeDatabse()
        {
            RunSqlScript(Resources.Schema);
            RunSqlScript(Resources.SP);
            RunSqlScript(Resources.Data);

        }

        private void RunSqlScript(string script)
        {
            using (var sqlConnection = GetOpennedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = script;

                string[] sqlInstructions = SplitSqlInstructions(script);

                foreach (string sqlInstruction in sqlInstructions)
                {
                    if (string.IsNullOrWhiteSpace(sqlInstruction))
                        continue;
                    cmd.CommandText = sqlInstruction;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string[] SplitSqlInstructions(string script)
        {
            return Regex.Split(script, @"\bGO\b");
        }

        private SqlConnection GetOpennedSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
