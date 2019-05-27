using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_DemoApp19.City.Core
{
    public class CityGetModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The city's name must be less then 100 characters")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Description must be less then 300 characters")]
        public string Description { get; set; }

        [Range(1, 30, ErrorMessage = "Count of NumberOfInterest must be in range between 1 and 30")]
        public int NumberOfPointsOfInterest { get; set; }
    }
}
