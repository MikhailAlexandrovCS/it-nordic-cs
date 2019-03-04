using System;

namespace DemoApp4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите первое число: ");
			int first = int.Parse(Console.ReadLine());
			Console.Write("Введите второе число: ");
			int second = int.Parse(Console.ReadLine());
			Console.WriteLine("\n" + first.ToString() + " больше " + second.ToString() + ":" + (first > second));
			Console.WriteLine(second.ToString() + " больше " + first.ToString() + ":" + (second > first));
			Console.WriteLine(first.ToString() + " больше или равна " + second.ToString() + ":" + (first >= second));
			Console.WriteLine(second.ToString() + " больше или равна " + first.ToString() + ":" + (second >= first));
			Console.WriteLine(first.ToString() + " меньше или равна " + second.ToString() + ":" + (first <= second));
			Console.WriteLine(second.ToString() + " меньше или равна " + first.ToString() + ":" + (second <= first));
			//------------------------------
			Console.Write("Введите число: ");
			long number = long.Parse(Console.ReadLine());
			Console.WriteLine(number.GetType().ToString());
			if (number <= int.MaxValue && number >= int.MinValue)
				Console.WriteLine((int)number + " " + number.GetType().ToString());
			else
				Console.WriteLine("Значение превосходит максимально возможное");
			//-------------
			Console.Write("Введите а: ");
			double a = double.Parse(Console.ReadLine());
			Console.Write("Введите h: ");
			double h = double.Parse(Console.ReadLine());
			Console.WriteLine("S боковое грани: " + Math.Round(((double)3 * a * h), 2).ToString());
			Console.WriteLine("S полной поверхности: " + Math.Round(((3 / 2) * a * (a * Math.Sqrt(3) + 2 * h)), 3).ToString());
			Console.WriteLine("V объем пирамиды: " + Math.Round(Math.Pow(a, 2) / 2 * (h / Math.Sqrt(2)) * Math.Sqrt(3), 3).ToString());
			Console.ReadKey();
		}
	}
}
