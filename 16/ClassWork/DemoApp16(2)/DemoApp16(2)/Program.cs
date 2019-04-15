using System;
using Calculator.Figure;
using Calculator.Operation;
using Newtonsoft.Json;

namespace DemoApp16_2_
{
	public class Person
	{
		public string Name;
		public int Age;
	}

	class Program
	{
		static void Main(string[] args)
		{
			var person = new Person
			{
				Name = "Mikhail",
				Age = 22
			};
			var pakedJSON = JsonConvert.SerializeObject(person);
			Console.WriteLine(pakedJSON);
			var newObject = JsonConvert.DeserializeObject<Person>(pakedJSON);
			Console.WriteLine(newObject.Name + " " + newObject.Age);
			//Figure figure = new Figure(3.0);
			//CircleInformater.CircleArea(3.0);
			//Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}
