using System;

namespace ADO_NET
{
	class Program
	{
		static void Main(string[] args)
		{
			const string connectionStringTemplate =
				"Data Source={0};Initial Catalog={1};Integrated Security=true;";

			string connectionString = string.Format(connectionStringTemplate, @"localHost\SQLEXPRESS", "OnlineStore");

			var onlineStoreRepository = new OnlineStoreRepository(connectionString);

			int productCount = onlineStoreRepository.GetProductCount();

			int newId = onlineStoreRepository.AddProduct("Super Watch", (decimal)12345.67);
			Console.Write(newId);

			//Console.Write($"Number of products: {productCount}");

			var products = onlineStoreRepository.GetProductList();
			foreach (var item in products)
				Console.WriteLine(item);

			//var orderListID = onlineStoreRepository.GetOrderDiscountList();
			//foreach (var item in orderListID)
			//	Console.WriteLine(item);


			Console.ReadKey();
		}
	}
}
