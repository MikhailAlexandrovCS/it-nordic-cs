using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_NET
{
	interface IOrderRepository
	{
		int GetOrderCount();

		List<string> GetOrderDiscountList();

		int AddOrder(int customerId, DateTimeOffset orderDate, float? discount, List<Tuple<int, int>> productIdCountList);
	}
}
