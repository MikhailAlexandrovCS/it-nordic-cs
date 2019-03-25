using System;

namespace DemoApp10
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet pet = new Pet
			{
				Kind = "Dog",
				Name = "Ryzhik",
				Sex = 'M',
				Age = 11
			};
			pet.WritePropertyToConsole();
			Console.WriteLine();
			Pet pet2 = new Pet();
			pet2.Kind = "Cat";
			pet2.Name = "Boris";
			pet2.Sex = 'M';
			pet2.Age = 9;
			pet2.WritePropertyToConsole();
			Console.ReadKey();
		}
	}
}
