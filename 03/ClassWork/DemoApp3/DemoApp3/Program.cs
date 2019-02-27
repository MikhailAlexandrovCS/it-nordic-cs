using System;

namespace DemoApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			object operand1 = 10;
			object operand2 = 2.515654;
			Console.WriteLine((Convert.ToUInt32(operand1) + 5).ToString());
			Console.WriteLine(Convert.ToDouble(operand1) * (double)operand2);
			Console.WriteLine(operand1.Equals(operand2));
			//----------------------------------------------------------------
			dynamic operandD1 = 10;
			dynamic operandD2 = "2.453546546";
			Console.WriteLine((operandD1 + 5));
			Console.WriteLine(operandD1 + double.Parse(operandD2, System.Globalization.CultureInfo.InvariantCulture.NumberFormat));
			//----------------------------------------------------------------
			var first = 3.14f;
			var second = -1d;
			var third = 49L;
			var fourth = (byte)255;
			Console.Write(first.GetType() + "\n" + second.GetType() + "\n" + third.GetType() + "\n" + fourth.GetType());
			//----------------------------------------------------------------
			Console.WriteLine(default(string) is null);
			double? d = null;
			do
			{
				try
				{
					d = Convert.ToDouble(Console.ReadLine());
				}
				catch { }
			}
			while (!d.HasValue);
			Console.WriteLine(d.Value.ToString());
			//----------------------------------------------------------------
			string[] temp = new string[5];
			for (int i = 0; i < temp.Length; i++)
				temp[i] = Console.ReadLine();
			Console.WriteLine("-----------------------------");
			for (int i = 0; i < temp.Length; i++)
				Console.WriteLine(temp[i]);
			Console.ReadKey();
		}
	}
}
