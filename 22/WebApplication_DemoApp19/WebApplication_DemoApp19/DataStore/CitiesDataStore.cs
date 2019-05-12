using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_DemoApp19.Models;

namespace WebApplication_DemoApp19.DataStore
{
    public class CitiesDataStore
    {
        public List<CityGetModel> Cities { get; private set; }
        private static CitiesDataStore _citiesDataStore;

        private CitiesDataStore()
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

        public static CitiesDataStore GetInstance()
        {
            if (_citiesDataStore == null)
                _citiesDataStore = new CitiesDataStore();
            return _citiesDataStore;
        }
    }
}
