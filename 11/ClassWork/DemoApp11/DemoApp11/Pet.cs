using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp11
{
	class Pet
	{
		public string Kind;
		public string Name;
		public char Sex;
		public DateTimeOffset DateOfBirth;

		public string Description
		{
			get
			{
				return $"{Name} id a {Kind} ({Sex}) of {Age} years old";
			}
		}

		public int Age
		{
			get
			{
				TimeSpan age = DateTimeOffset.Now.Subtract(DateOfBirth);
				return Convert.ToInt32(Math.Floor(age.TotalDays / 365.242));
			}
		}

		public void WritePropertyToConsole(bool isShortDescription)
		{
			Console.Write(isShortDescription ? ShortDescription : Description);
		}

		public string ShortDescription
		{
			get
			{
				return $"{Name} id a {Kind}";
			}
		}
	}
}
