using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp10
{
	class Pet
	{
		public string Kind;
		public string Name;
		public char Sex;
		public int Age;

		public string PropertyString
		{
			get
			{
				return $"{Name} id a {Kind} ({Sex}) of {Age} years old";
			}
		}
		
		public void WritePropertyToConsole()
		{
			Console.Write(PropertyString);
		}
	}
}
