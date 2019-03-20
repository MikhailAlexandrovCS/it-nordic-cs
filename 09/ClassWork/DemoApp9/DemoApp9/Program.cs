using System;
using System.Diagnostics;

namespace DemoApp9
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Время работы алгоритма Buble:" + "\t" + "Время работы алгоритма (.NET):");
			int length = 1000;
			while (true)
			{
				
				int[] initialArray = GetTestAray(length, 1_000_000);
				//WriteArrayState("Массив до сортировки: ", initialArray);

				int[] sortedBubleArray = (int[])initialArray.Clone();
				int[] dotNetSortedArray = (int[])initialArray.Clone();
				Stopwatch sw = new Stopwatch();
				sw.Start();
				BubleSortArray(sortedBubleArray);
				//WriteArrayState("Массив после сортировки: ", sortedBubleArray);
				sw.Stop();
				long buble = sw.ElapsedMilliseconds;
				sw.Restart();
				Array.Sort(dotNetSortedArray);
				long dotnet = sw.ElapsedMilliseconds;
				sw.Stop();
				if (length == 200000)
					break;
				Console.WriteLine(buble + "\t\t\t\t" + dotnet);
				Console.WriteLine("==================================================");
				length += 1000;
			}
			Console.ReadKey();
		}

		private static void BubleSortArray(int[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				int limit = array.Length - 1 - i;
				for (int j = 0; j < limit; j++)
					if (array[j] > array[j + 1])
					{
						int temp = array[j];
						array[j] = array[j + 1];
						array[j + 1] = temp;
					}
			}
		}

		private static void WriteArrayState(string messsage, int[] array)
		{
			Console.WriteLine(messsage);
			foreach (int elem in array)
				Console.WriteLine(elem);
		}

		private static int[] GetTestAray(int length, int maxValue)
		{

			var rand = new Random();

			var array = new int[length];

			for (int i = 0; i < array.Length; i++)
				array[i] = rand.Next(maxValue);

			return array;
		}
	}
}
