using System;

namespace DemoApp14
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ErrorList errorList = new ErrorList("Error"))
			{
				errorList.Add("Неправильный формат");
				errorList.Add("Неправильный лог");
				errorList.Add("Неправильный знак");
				errorList.WriteToConsole();
				//foreach (var error in errorList)
				//	Console.WriteLine(errorList.Category + $": {error}");
			}
			Console.ReadKey();
		}
	}
}
