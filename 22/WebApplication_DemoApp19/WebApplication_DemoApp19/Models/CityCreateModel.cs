﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_DemoApp19.Validation;

namespace WebApplication_DemoApp19.Models
{
    public class CityCreateModel
    {
		[Required]
		[MaxLength(100, ErrorMessage = "The name of the city should be less than 100 characters")]
        public string Name { get; set; }

		[MaxLength(255, ErrorMessage = "Description should be not longer than 255 characters")]
		[DifferentValue(OtherProperty = "Name")]
		public string Description { get; set; }

		[Range(0, 100, ErrorMessage = "Number of interest should be between 0 and 100 counts")]
		public int NumberOfPointsOfInterest { get; set; }
    }
}
