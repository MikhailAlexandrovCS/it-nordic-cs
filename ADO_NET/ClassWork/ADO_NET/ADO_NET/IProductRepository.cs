using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_NET
{
	interface IProductRepository
	{
		int GetProductCount();

		List<string> GetProductList();
	}
}
