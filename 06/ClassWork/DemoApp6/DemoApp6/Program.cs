﻿using System;

namespace DemoApp6
{
	class Program
	{
		static void Main(string[] args)
		{
            string tmp;
            do
            {
                Console.Write("Введите слово: ");
                tmp = Console.ReadLine();
                if (tmp == "exit")
                    break;
                if (tmp.Length <= 15)
                    Console.WriteLine("Длина строки: " + tmp.Length);
                else
                {
                    Console.WriteLine("Слишком длинная строка. Попробуйте другую.");
                    continue;
                }
            }
            while (true);
            //----------------------------------------------------------
            int[] numbers = { 4, 8, 1, 4, 8, 3, 4 };
            int sum = 0;
            int iteration = 0;
            while (true)
            {
                if (iteration == numbers.Length)
                    break;
                sum += numbers[iteration];
                Console.WriteLine("Промежуточная сумма: " + sum);
                iteration++;
            }
            //----------------------------------------------------------
            var marks = new[]
			{
				new[] {2, 3, 3, 2, 3},
				new[] {2, 4, 5, 3},
				null,
				new[] {5, 5, 5, 5},
				new[] {4}
			};
			double avgValue = 0;
			double avgDay = 0;
            double del = 0;
			for (int i = 0; i < marks.Length; i++)
			{
				try
				{
					for (int j = 0; j < marks[i].Length; j++)
					{
						avgValue += marks[i][j];
                        del = marks[i].Length;
					}
                    avgDay += avgValue / del;
                    Console.WriteLine("Средний балл за день " + (i + 1).ToString() + ": " + (avgValue / del).ToString());
                    avgValue = 0;
                }
				catch(NullReferenceException e)
				{
					Console.WriteLine("Средний балл за день " + (i + 1).ToString() + ": N/A");
					continue;
				}
			}
			Console.WriteLine("Средний балл за неделю: " + (avgDay / marks.Length));
			Console.ReadKey();
		}
	}
}
