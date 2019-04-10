using System;

namespace DemoApp15
{
	class Program
	{
		static void Main(string[] args)
		{
			Account<int> accountFirst = new Account<int>("Mikhail", 2);
			accountFirst.WriteProperties();

			Account<string> accountSecond = new Account<string>("Nikolay", "2");
			accountSecond.WriteProperties();

			Account<Guid> accountThird = new Account<Guid>("Vladimir", Guid.NewGuid());
			accountThird.WriteProperties();

			Circle circle = new Circle(1.5);
			Console.ReadKey();
		}

		public static void CircleInfo(Circle circle)
		{
			double perimeter = circle.Calculate(CircleInformater.CirclePerimeter);
			double area = circle.Calculate(CircleInformater.CircleArea);

		}
	}
}
