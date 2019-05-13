using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_DemoApp19.Models;

namespace WebApplication_DemoApp19.DataStore
{
	public interface ICitiesDataStore
	{
		List<CityGetModel> Cities { get;}
	}
}
