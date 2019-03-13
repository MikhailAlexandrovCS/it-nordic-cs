using System;

namespace SchoolMarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var marks = new[]
            {
                new[] {2, 3, 3, 2, 3},
                new[] {2, 4, 5, 3},
                null,
                new[] {5, 5, 5, 5},
                new[] {4}
            };

            double avgDay = 0;
            double avgValue = 0;
            int marksCount = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                try
                {
                    for (int j = 0; j < marks[i].Length; j++)
                    {
                        avgValue += marks[i][j];
                        avgDay += marks[i][j];
                    }
                    marksCount += marks[i].Length;
                    Console.WriteLine("Средний балл за день #" + (i + 1).ToString() + ": " + (avgDay / marks[i].Length).ToString());
                    avgDay = 0;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Средний балл за день " + (i + 1).ToString() + ": N/A");
                    continue;
                }
            }

            Console.WriteLine("Средний балл за неделю: " + Math.Round((avgValue / marksCount), 1));
            Console.ReadKey();
        }
    }
}
