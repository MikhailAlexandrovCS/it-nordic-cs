using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO_NET
{
	public partial class OnlineStoreRepository
	{
		public int GetProductCount()
		{
			using (var sqlConnection = GetOpennedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT COUNT(*) FROM dbo.Product";
				var result = (int)sqlCommand.ExecuteScalar();
				return result;
			}
		}

		public List<string> GetProductList()
		{
			var result = new List<string>();
			using (var sqlConnection = GetOpennedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT Id, Name, Price FROM dbo.Product ORDER BY Price ASC";
				using (var sqlDataReader = sqlCommand.ExecuteReader())
				{
					if (!sqlDataReader.HasRows)
						return result;
					int idColumnIndex = sqlDataReader.GetOrdinal("Id");
					int nameColumnIndex = sqlDataReader.GetOrdinal("Name");
					int priceColumnIndex = sqlDataReader.GetOrdinal("Price");
					while (sqlDataReader.Read())
					{
						var id = sqlDataReader.GetInt32(idColumnIndex);
						var name = sqlDataReader.GetString(nameColumnIndex);
						var price = sqlDataReader.GetDecimal(priceColumnIndex);

						result.Add($"Product ID: {id}\tName: {name}\t (Price:{price}");
					}
					return result;
				}
			}
		}

		public int AddProduct(string name, decimal price)
		{
			using (var sqlConnection = GetOpennedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "dbo.AddProduct";

				sqlCommand.Parameters.AddWithValue("@name", name);
				sqlCommand.Parameters.AddWithValue("@price", price);

				var outputIdParameter = new SqlParameter("@id", System.Data.SqlDbType.Int);
				outputIdParameter.Direction = System.Data.ParameterDirection.Output;
				sqlCommand.Parameters.Add(outputIdParameter);

				sqlCommand.ExecuteNonQuery();
				return (int)outputIdParameter.Value;
			}
		}
	}
}
