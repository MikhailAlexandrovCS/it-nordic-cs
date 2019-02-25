using System;

namespace DemoApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			char letter = 'A';
			Console.WriteLine(letter);
			string name = "Bob";
			string name2 = name.ToUpper();
			string name3 = name.ToUpper().Replace('O', 'B');
			Console.WriteLine(name + "\t" + name2 + "\t" + name3);
			//--------------------------------------------------------------------
			float x1 = 3.5f;
			Console.WriteLine(x1);
			int x = 3;
			float y = 4.5f;
			short z = 5;
			var result = x * y / z;
			Console.WriteLine("This result is {0}", result);
			Type type = result.GetType();
			Console.WriteLine("Result of type is {0}", type.ToString());
			float notNumber = float.NaN;
			float infinity = float.PositiveInfinity;
			float zero = 0;
			Console.WriteLine("{0} / {0} = {1}", zero, zero / zero);
			Console.WriteLine(zero / zero == float.NaN);
			Console.WriteLine(float.IsNaN(zero / zero));
			//--------------------------------------------------------------------
			Console.Write("Введите радиу круга: ");
			string radius = Console.ReadLine();
			Console.WriteLine("Площадь круга: " + Math.Pow(Convert.ToDouble(radius), 2) * Math.PI);
			Console.ReadKey();
		}
	}
}
