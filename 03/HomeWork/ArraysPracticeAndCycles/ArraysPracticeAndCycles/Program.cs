using System;
using System.Globalization;

namespace ArraysPracticeAndCycles
{
    internal class Program
    {
        private const int _peopleCount = 3;
        private const int _incrementForAge = 4;
        public static void work(ConsoleInput input, ConsoleOutput output, string[] names, int[] ages)
        {
            names = input.GetValuesOfNamesFromUserByKeyboard(names);
            ages = input.GetValuesOfAgesFromUserByKeyboard(ages);
            output.Output(names, ages, _incrementForAge);
        }
        static void Main(string[] args)
        {
            string[] names = new string[_peopleCount];
            int[] ages = new int[names.Length];
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            var counting = new Counting();
            var consoleChangColor = new ConsoleChangeColor();
            var writer = new ConsoleWriter(cultureInfo, consoleChangColor);
            var inputWork = new ConsoleInput(writer);
            var outputWork = new ConsoleOutput(writer, counting);
            work(inputWork, outputWork, names, ages);
            Console.ReadKey();
        }
    }
}
