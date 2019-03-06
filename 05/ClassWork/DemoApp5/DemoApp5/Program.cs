using System;

namespace DemoApp5
{
	class Program
	{
		[Flags]
		public enum Colors
		{
			Black = 1,
			Blue = 2,
			Cyan = 3,
			Grey = 4,
			Green = 5,
			Magenta = 6,
			Red = 7,
			White = 8,
			Yellow = 9
		}
		public static object GetColorFromUser()
		{
			object color;
			bool isColors;
			do
			{
				isColors = Enum.TryParse(typeof(Colors), Console.ReadLine(), out color);
			}
			while (!isColors);
			return color;
		}
		public static bool IsContains(Colors[] favoriteColors, string color)
		{
			for (int i = 0; i < favoriteColors.Length; i++)
				if (favoriteColors[i].ToString() == color)
					return false;
			return true;
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Введите 4 избранных цвета: ");
			Colors[] favoriteColors = new Colors[4];
			string[] allColors = Enum.GetNames(typeof(Colors));
			for (int i = 0; i < favoriteColors.Length; i++)
				favoriteColors[i] = (Colors)GetColorFromUser();
			Console.WriteLine("Избранные цвета: ");
			for (int i = 0; i < favoriteColors.Length; i++)
				Console.WriteLine(favoriteColors[i]);
			Console.WriteLine("Оставшиеся цвета: ");
			for (int i = 0; i < allColors.Length; i++)
				if (IsContains(favoriteColors, allColors[i]))
					Console.WriteLine(allColors[i]);
			//-----------------------------------------------------
			try
			{
				Console.Write("Введите число: ");
				Console.Write("Число" + (int.Parse(Console.ReadLine()) >= 0 ? " неотрицательное" : " отрицательное"));
			}
			catch (FormatException e)
			{
				Console.WriteLine("Введены неверные данные!\n" + e.GetType());
				throw;
			}
			//-----------------------------------------------------

			Console.ReadKey();
		}
	}
}
