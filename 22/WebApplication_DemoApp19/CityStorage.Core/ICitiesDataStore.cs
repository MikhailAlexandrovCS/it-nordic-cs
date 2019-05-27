using System.Collections.Generic;

namespace WebApplication_DemoApp19.City.Core
{
    public interface ICitiesDataStore
	{
		List<CityGetModel> Cities { get;}
	}
}
