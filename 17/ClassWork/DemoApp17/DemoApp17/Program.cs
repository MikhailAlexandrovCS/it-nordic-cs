using System;

namespace DemoApp17
{
	class Program
	{
		static void Main(string[] args)
		{
			//WorkPerfomedEventHandler del1 = WorkPerfomed1;
			//WorkPerfomedEventHandler del2 = WorkPerfomed2;
			//WorkPerfomedEventHandler del3 = WorkPerfomed3;

			//del1 += del2 + del3;

			//int result = del1(8, WorkType.DoNothing);
			//Console.WriteLine($"Result: {result} hours");

			Worker worker = new Worker();
			worker.WorkPerfomed += Worker_WorkPerfomed;
			worker.WorkCompleted += Worker_WorkCompleted;
			worker.DoWork(6, WorkType.Work);

			Console.ReadKey();
		}

		private static void Worker_WorkCompleted(object sender, EventArgs e)
		{
			Console.Write($"Work DONE ({sender.GetHashCode()})");
		}

		private static void Worker_WorkPerfomed(int hours, WorkType workType)
		{
			Console.WriteLine($"Work of type: {workType}: {hours} hours");
		}

		//private static int WorkPerfomed3(int hours, WorkType workType)
		//{
		//	Console.Write($"WorkPerfomed3: " +
		//		$"Work of type {workType.ToString()}: {hours} hours\n");
		//	return hours + 3;
		//}

		//private static int WorkPerfomed2(int hours, WorkType workType)
		//{
		//	Console.Write($"WorkPerfomed2: " +
		//		$"Work of type {workType.ToString()}: {hours} hours\n");
		//	return hours + 2;
		//}

		//private static int WorkPerfomed1(int hours, WorkType workType)
		//{
		//	Console.Write($"WorkPerfomed1: " +
		//		$"Work of type {workType.ToString()}: {hours} hours\n");
		//	return hours + 1;
		//}
	}
}
