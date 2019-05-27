using System.Collections.Generic;
using WebApplication_DemoApp19.City.Core;

namespace WebApplication_DemoApp19.City.InMemory
{
    public class CitiesDataStore : ICitiesDataStore
    {
        public List<CityGetModel> Cities { get; private set; }

		public CitiesDataStore()
		{
			Cities = new List<CityGetModel>
			{
					new CityGetModel
					{
						Id = 1,
						Name = "Moscow",
						Description = "The capital of Russia"
					},
					new CityGetModel
					{
						Id = 2,
						Name = "New York",
						Description = "One of the most biggest cities in the world"
					}
			};
		}
    }
}
