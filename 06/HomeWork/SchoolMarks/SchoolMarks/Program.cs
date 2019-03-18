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

            for (int day = 0; day < marks.Length; day++)
            {
                if (marks[day] != null)
                {
                    for (int marksInDay = 0; marksInDay < marks[day].Length; marksInDay++)
                    {
                        avgValue += marks[day][marksInDay];
                        avgDay += marks[day][marksInDay];
                    }
                    marksCount += marks[day].Length;
                    Console.WriteLine("Средний балл за день #" + (day + 1).ToString() + ": " + (avgDay / marks[day].Length).ToString());
                    avgDay = 0;
                }
                else
                    Console.WriteLine("Средний балл за день #" + (day + 1).ToString() + ": N/A");
            }

            Console.WriteLine("Средний балл за неделю: " + Math.Round((avgValue / marksCount), 1));
            Console.ReadKey();
        }
    }
}
