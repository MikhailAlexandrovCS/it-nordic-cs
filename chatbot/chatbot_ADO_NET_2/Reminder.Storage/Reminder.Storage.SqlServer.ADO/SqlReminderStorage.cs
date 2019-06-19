using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Reminder.Storage.Core;

namespace Reminder.Storage.SqlServer.ADO
{
	public class SqlReminderStorage : IReminderStorage
	{
		private readonly string _connectionString;

		public SqlReminderStorage(string connectionString)
		{
			_connectionString = connectionString;
		}

		public int Count
        {
            get
            {
                using (var sqlConnection = GetOpenedSqlConnection())
                {
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[GetReminderItemsCount]";

                    

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

		public Guid Add(ReminderItemRestricted reminder)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.AddReminderItem";

				cmd.Parameters.AddWithValue("@contactId", reminder.ContactId);
				cmd.Parameters.AddWithValue("@targetDate", reminder.Date);
				cmd.Parameters.AddWithValue("@message", reminder.Message);
				cmd.Parameters.AddWithValue("@statusId", (byte)reminder.Status);

				var outputIdParameter = new SqlParameter("@reminderId", System.Data.SqlDbType.UniqueIdentifier, 1);
				outputIdParameter.Direction = System.Data.ParameterDirection.Output;
				cmd.Parameters.Add(outputIdParameter);

				cmd.ExecuteNonQuery();

				return (Guid)outputIdParameter.Value;
			}
		}

		public ReminderItem Get(Guid id)
		{
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetReminderItemById";

                cmd.Parameters.AddWithValue("@reminderId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows || !reader.Read())
                        return null;

                    var result = new ReminderItem();

                    result.Id = id;
                    result.ContactId = reader.GetString(reader.GetOrdinal("ContactId"));
                    result.Date = reader.GetDateTimeOffset(reader.GetOrdinal("TargetDate"));
                    result.Message = reader.GetString(reader.GetOrdinal("Message"));
                    result.Status = (ReminderItemStatus)reader.GetByte(reader.GetOrdinal("StatusId"));

                    return result;
                }
            }
        }

		public List<ReminderItem> Get(int count = 0, int startPostion = 0)
		{
            var result = new List<ReminderItem>();
            result.AddRange(Get(ReminderItemStatus.Awaiting));
            result.AddRange(Get(ReminderItemStatus.Ready));
            result.AddRange(Get(ReminderItemStatus.Sent));
            result.AddRange(Get(ReminderItemStatus.Failed));
            return result;
        }

		public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
		{
            return Get(status);
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
            List<ReminderItem> items = new List<ReminderItem>();
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetListReminderItemByStatus";

                cmd.Parameters.AddWithValue("@reminderItemStatus", (byte)status);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int idColumnIndex = reader.GetOrdinal("Id");
                    int contactIdColumnIndex = reader.GetOrdinal("ContactId");
                    int targetDateColumnIndex = reader.GetOrdinal("TargetDate");
                    int messageColumnIndex = reader.GetOrdinal("Message");
                    int statusColumnIndex = reader.GetOrdinal("StatusId");

                    while (true)
                    {
                        if (!reader.HasRows || !reader.Read())
                            break;

                        var result = new ReminderItem
                        {
                            Id = reader.GetGuid(idColumnIndex),
                            ContactId = reader.GetString(contactIdColumnIndex),
                            Date = reader.GetDateTimeOffset(targetDateColumnIndex),
                            Message = reader.GetString(messageColumnIndex),
                            Status = (ReminderItemStatus)reader.GetByte(statusColumnIndex)
                        };
                        

                        items.Add(result);
                    }
                }
            
                return items;
            }
        }

		public bool Remove(Guid id)
		{
            using (SqlConnection sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[RemoveReminderItem]";
                cmd.Parameters.AddWithValue("@guid", id);
                return (bool)cmd.ExecuteScalar();
            }
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
            //foreach (var item in ids)
            //    UpdateStatus(item, status);
            using (SqlConnection sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE #ReminderItem([Id] UNIQUEIDENTIFIER NOT NULL)";

                using (SqlBulkCopy copy = new SqlBulkCopy(sqlConnection))
                {
                    copy.BatchSize = 1000;
                    copy.DestinationTableName = "#ReminderItem";
                    DataTable tempTable = new DataTable("#ReminderItem");
                    tempTable.Columns.Add("Id", typeof(Guid));
                    foreach(Guid id in ids)
                    {
                        DataRow row = tempTable.NewRow();
                        row["Id"] = id;
                        tempTable.Rows.Add(row);
                    }
                    copy.WriteToServer(tempTable);

                }


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.UpdateReminderItemsByid";
                cmd.Parameters.AddWithValue("@status", (byte)status);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DROP TABLE #ReminderItem";
                cmd.ExecuteNonQuery();
            }
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.UpdateStatusByGuid";
                cmd.Parameters.AddWithValue("@guid", id);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            }
        }

		private SqlConnection GetOpenedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();

			return sqlConnection;
		}
	}
}
