using System;

namespace DemoApp7
{
	class Program
	{
		static void Main(string[] args)
		{
			double first = double.Parse(Console.ReadLine());
			double second = double.Parse(Console.ReadLine());

			Console.WriteLine(first + " * " + second + " = " + (first * second));
			Console.WriteLine(String.Format("{0:##.##} + {1:##.##} = {2:##.##}", first, second, (first + second)));
			Console.WriteLine($"{first:##.##} - {second:##.##} = {(first - second):##.##}");
			//------------------------------------------------------------------------------------------------
			string test = "my string test";
			Console.WriteLine(test.Substring(0, test.Length));
			//------------------------------------------------------------------------------------------------
			Console.ReadKey();
		}
	}
}
