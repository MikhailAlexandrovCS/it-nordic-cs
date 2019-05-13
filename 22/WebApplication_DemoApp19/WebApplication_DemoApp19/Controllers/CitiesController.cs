using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
		ILogger<CitiesController> _logger;
		ICitiesDataStore _citiesDataStore;

		public CitiesController(ILogger<CitiesController> logger, ICitiesDataStore citiesDataStore)
		{
			_logger = logger;
			_citiesDataStore = citiesDataStore;
		}

        [HttpGet()]
        public IActionResult GetCities()
        {
			_logger.LogInformation($"{nameof(GetCities)} called");

            
            var cities = _citiesDataStore.Cities;
            return Ok(cities);
        }

        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id)
        {
            
            var city = _citiesDataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost()]
        public IActionResult CreateCity([FromBody] CityCreateModel city)
        {
            if (city == null)
                BadRequest();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

            
            int newCityId = _citiesDataStore.Cities.Max(c => c.Id) + 1;

            var newCity = new CityGetModel
            {
                Id = newCityId,
                Name = city.Name,
                Description = city.Description,
                NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
            };

            _citiesDataStore.Cities.Add(newCity);

            return CreatedAtRoute("GetCity", new { id = newCityId }, newCity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            
            var city = _citiesDataStore.Cities.Where(c => c.Id.Equals(id)).FirstOrDefault();

            if (city == null)
                NotFound();

            _citiesDataStore.Cities.Remove(city);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCity([FromBody] CityCreateModel cityCreateModel, int id)
        {
            
            var city = _citiesDataStore.Cities.Where(c => c.Id.Equals(id)).First();

            if (city.Equals(null))
                NotFound();

            city = new CityGetModel
            {
                Id = id,
                Name = cityCreateModel.Name,
                Description = cityCreateModel.Description,
                NumberOfPointsOfInterest = cityCreateModel.NumberOfPointsOfInterest
            };

            _citiesDataStore.Cities[city.Id - 1] = city;

            return CreatedAtRoute("GetCity", new { id = city.Id }, city);

        }
    }
}
