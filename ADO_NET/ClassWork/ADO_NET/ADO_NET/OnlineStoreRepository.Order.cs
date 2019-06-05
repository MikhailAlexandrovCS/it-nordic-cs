using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO_NET
{
	public partial class OnlineStoreRepository
	{
		public int GetOrderCount()
		{
			using (var sqlConnection = GetOpennedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT COUNT(*) FROM dbo.Order";
				var result = sqlCommand.ExecuteScalar();
				return (int)result;
			}
		}


		public List<string> GetOrderDiscountList()
		{
			List<string> orderList = new List<string>();
			using (var sqlConnection = GetOpennedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT Id FROM dbo.[Order]";
				using (var sqlDataReader = sqlCommand.ExecuteReader())
				{
					if (!sqlDataReader.HasRows)
						return orderList;
					int idColumnIndex = sqlDataReader.GetOrdinal("Id");
					while(sqlDataReader.Read())
					{
						var id = sqlDataReader.GetInt32(idColumnIndex);
						orderList.Add($"id: {id}");
					}
					return orderList;
				}
			}
		}

		public int AddOrder(int customerId, DateTimeOffset orderDate, float? discount, List<Tuple<int, int>> productIdCountList)
		{
			using (var sqlConnection = GetOpennedSqlConnection())
			{

				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "dbo.AddOrder";

				sqlCommand.Parameters.AddWithValue("@customerId", customerId);
				sqlCommand.Parameters.AddWithValue("@orderDate", orderDate);
				sqlCommand.Parameters.AddWithValue("@discount", discount);

				var outputParameterIdOrder = new SqlParameter("@id", System.Data.SqlDbType.Int);
				outputParameterIdOrder.Direction = System.Data.ParameterDirection.Output;
				sqlCommand.Parameters.Add(outputParameterIdOrder);

				sqlCommand.ExecuteNonQuery();

				for (int i = 0; i < productIdCountList.Count; i++)
				{
					var sqlCommandAddOrderItem = sqlConnection.CreateCommand();
					sqlCommandAddOrderItem.CommandType = System.Data.CommandType.StoredProcedure;
					sqlCommandAddOrderItem.CommandText = "dbo.AddOrderItem";

					sqlCommandAddOrderItem.Parameters.AddWithValue("@orderId", outputParameterIdOrder);
					sqlCommandAddOrderItem.Parameters.AddWithValue("@productId", productIdCountList[i].Item1);
					sqlCommandAddOrderItem.Parameters.AddWithValue("@numberOfItems", productIdCountList[i].Item2);

					sqlCommand.ExecuteNonQuery();
				}
				return (int)outputParameterIdOrder.Value;
			}
		}
	}
}
