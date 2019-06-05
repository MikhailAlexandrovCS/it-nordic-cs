using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO_NET
{
	public partial class OnlineStoreRepository : IProductRepository, IOrderRepository
	{
		private readonly string _connectionString;

		public OnlineStoreRepository(string connectionString)
		{
			_connectionString = connectionString;
		}


		private SqlConnection GetOpennedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();
			return sqlConnection;
		}
	}
}
