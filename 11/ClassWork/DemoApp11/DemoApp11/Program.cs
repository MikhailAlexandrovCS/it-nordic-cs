using System;

namespace DemoApp11
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
				DateOfBirth = DateTimeOffset.Parse("2011-03-12")
			};
			pet.WritePropertyToConsole(false);
			Console.WriteLine();
			Pet pet2 = new Pet();
			pet2.Kind = "Cat";
			pet2.Name = "Boris";
			pet2.Sex = 'M';
			pet2.DateOfBirth = DateTimeOffset.Parse("2010-10-12");
			pet2.WritePropertyToConsole(true);
			Console.ReadKey();
		}
	}
}
