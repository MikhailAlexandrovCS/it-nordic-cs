using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysPracticeAndCycles
{
    class ConsoleInput
    {
        private readonly ConsoleWriter consoleWriter;
        public ConsoleInput(ConsoleWriter pconsoleWriter)
        {
            consoleWriter = pconsoleWriter;
        }
        public string[] GetValuesOfNamesFromUserByKeyboard(string[] names)
        {
            consoleWriter.WriteText(Properties.Resources.InputNamesProcess + "\n", ConsoleColor.White);
            for (int namesIndex = 0; namesIndex < names.Length; namesIndex++)
            {
                consoleWriter.WriteText(Properties.Resources.Name, ConsoleColor.White);
                names[namesIndex] = Console.ReadLine();
                Console.MoveBufferArea(0, namesIndex + 1, Console.BufferWidth, 1, Console.BufferWidth, namesIndex + 1, ' ', Console.ForegroundColor, Console.BackgroundColor);
                Console.SetCursorPosition(Properties.Resources.Name.Length, namesIndex + 1);
                consoleWriter.WriteText(names[namesIndex], ConsoleColor.Yellow);
                Console.SetCursorPosition(names[namesIndex].Length * 2, namesIndex + 1);
                Console.WriteLine();
            }
            return names;
        }
        private int GetAgeValueWithCheck()
        {
            bool isCheck = false;
            int result;
            do
            {
                isCheck = int.TryParse(Console.ReadLine(), out result);
            }
            while (!isCheck);
            return result;
        }
        private int GetCountNumbersInAge(int age)
        {
            int countNumbers = 0;
            while(age > 0)
            {
                age /= 10;
                countNumbers++;
            }
            return countNumbers;
        }
        public int[] GetValuesOfAgesFromUserByKeyboard(int[] ages)
        {
            consoleWriter.WriteText(Properties.Resources.InputAgesProcess + "\n", ConsoleColor.White);
            for (int agesIndex = 0; agesIndex < ages.Length; agesIndex++)
            {
                consoleWriter.WriteText(Properties.Resources.Age, ConsoleColor.White);
                ages[agesIndex] = GetAgeValueWithCheck();
                Console.MoveBufferArea(0, agesIndex + 5, Console.BufferWidth, 1, Console.BufferWidth, agesIndex + 5, ' ', Console.ForegroundColor, Console.BackgroundColor);
                Console.SetCursorPosition(Properties.Resources.Age.Length, agesIndex + 5);
                consoleWriter.WriteText(ages[agesIndex].ToString(), ConsoleColor.Green);
                Console.SetCursorPosition(GetCountNumbersInAge(ages[agesIndex]), agesIndex + 5);
                Console.WriteLine();
            }
            return ages;
        }
    }
}
