using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_DemoApp19.DataStore;
using WebApplication_DemoApp19.Models;

namespace WebApplication_DemoApp19.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var cities = citiesDataStore.Cities;
            return Ok(cities);
        }

        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var city = citiesDataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost()]
        public IActionResult CreateCity([FromBody] CityCreateModel city)
        {
            if (city == null)
                BadRequest();

            var citiesDataStore = CitiesDataStore.GetInstance();
            int newCityId = citiesDataStore.Cities.Max(c => c.Id) + 1;

            var newCity = new CityGetModel
            {
                Id = newCityId,
                Name = city.Name,
                Description = city.Description,
                NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
            };

            citiesDataStore.Cities.Add(newCity);

            return CreatedAtRoute("GetCity", new { id = newCityId }, newCity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var city = citiesDataStore.Cities.Where(c => c.Id.Equals(id)).FirstOrDefault();

            if (city == null)
                NotFound();

            citiesDataStore.Cities.Remove(city);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCity([FromBody] CityCreateModel cityCreateModel, int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var city = citiesDataStore.Cities.Where(c => c.Id.Equals(id)).First();

            if (city.Equals(null))
                NotFound();

            city = new CityGetModel
            {
                Id = id,
                Name = cityCreateModel.Name,
                Description = cityCreateModel.Description,
                NumberOfPointsOfInterest = cityCreateModel.NumberOfPointsOfInterest
            };

            citiesDataStore.Cities[city.Id - 1] = city;

            return CreatedAtRoute("GetCity", new { id = city.Id }, city);

        }
    }
}
