using System;

namespace DemoApp16
{
	class Program
	{
		static void Main(string[] args)
		{
			//Circle circle = new Circle(1.5);
			//var calculatePerimeter = circle.Calculate((double radius) => Math.PI * 2 * radius);
			//var calculateArea = circle.Calculate((double radius) => Math.Pow(radius, 2) * Math.PI);
			//Console.WriteLine($"{calculateArea}\n{calculatePerimeter}");

			//Calculation s = new Calculation(new int[] { 3, 2, 8, 9, 2, 3 });
			//Console.Write(s.CalcSingleValue(
			//	(int[] array) =>
			//	{
			//		int sum = 0;
			//		for (int i = 0; i < array.Length; i++)
			//			sum += array[i];
			//		return sum / array.Length;
			//	}));
			Console.ReadKey();
		}

		private static int Sum(int[] array)
		{
			int sum = 0;
			for (int i = 0; i < array.Length; i++)
				sum += array[i];
			return sum;
		}
	}
}
