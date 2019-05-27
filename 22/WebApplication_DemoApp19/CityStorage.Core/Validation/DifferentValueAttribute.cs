using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication_DemoApp19.City.Core
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DifferentValueAttribute : ValidationAttribute
	{
		public string OtherProperty { get; set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

			if (otherPropertyInfo == null)
				return new ValidationResult($"Can not find the property with name {OtherProperty}");

			object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

			if (Equals(value, otherPropertyValue))
				return new ValidationResult($"The value of {validationContext.MemberName} should not be the same as {OtherProperty}");

			return ValidationResult.Success;
		}
	}
}
