using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoApp8
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = new List<int>();
			List<int> rangeNumbers = new List<int> { 4, 3, 5, 1, 5 };

			numbers.Add(4);
			numbers.Add(11);
			numbers.Add(5);
			numbers.Add(7);
			numbers.Add(41);
			numbers.Add(0);
			numbers.Add(-12);

			Console.WriteLine(string.Join(" ", numbers));

			numbers.Sort();
			numbers.AddRange(rangeNumbers);

			Console.WriteLine(string.Join(" ", numbers));

			numbers.RemoveRange(0, 5);

			Console.WriteLine(string.Join(" ", numbers));

			rangeNumbers.AddRange(new[] { 4, 3, 2, 1 });

			Console.WriteLine(string.Join(" ", rangeNumbers));

			rangeNumbers.RemoveRange(2, 4);

			Console.WriteLine(string.Join(" ", rangeNumbers));
			//------------------------------------------------------
			var dictionary = new Dictionary<string, string>
			{
				{"Russia", "Moscow" },
				{"Germany", "Berlin" },
				{"Spain", "Madrid" },
				{"Belarus", "Minsk" },
				{"Denmark", "Kopengagen" },
				{"Italy", "Rome" }
			};

			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				Console.WriteLine("Введите столицу страны (" + keyValuePair.Key + "): ");
				string city = Console.ReadLine()?.Trim();
				//KeyValuePair<string, string> tmp = new KeyValuePair<string, string>(keyValuePair.Key, city);
				if (keyValuePair.Value != city)
					break;
				else
					Console.WriteLine("Правильно!");
			}

			Console.WriteLine("Игра окончена!");
			//------------------------------------------------------
			Queue<int> numbers = new Queue<int>();
			while (true)
			{
				Console.Write("Введите число: ");
				string s = Console.ReadLine()?.Trim();

				if (s == "exit")
				{
					Console.WriteLine($"Осталось задач: {numbers.Count}");
					Console.WriteLine("Продолжить работу или выйти? (y/n)");
					if (Console.ReadKey().Key == ConsoleKey.N)
						break;
					else
						Console.WriteLine();
				}

				if (s == "run")
				{
					while (numbers.Count != 0)
					{
						int number = numbers.Dequeue();
						Console.WriteLine($"Квадратный корень из числа {number}: {Math.Round(Math.Sqrt(number), 2)}");
					}
				}

				if (s != "run" && s != "exit")
					numbers.Enqueue(int.Parse(s));
			}
			//------------------------------------------------------
			Stack<int> washes = new Stack<int>();
			while (true)
			{
				string s = Console.ReadLine();
				if (s == "wash")
				{
					washes.Push(1);
					Console.WriteLine($"Тарелок на вытирание: {washes.Count}");
				}
				if (s == "dry")
				{
					if (washes.Count != 0)
					{
						washes.Pop();
						Console.WriteLine($"Тарелок на вытирание: {washes.Count}");
					}
					else
						Console.WriteLine("Стопка тарелок пуста!");
				}
				if (s == "exit")
				{
					Console.WriteLine($"Тарелок на вытирание: {washes.Count}");
					break;
				}
			}
			Console.ReadKey();
		}
	}
}
