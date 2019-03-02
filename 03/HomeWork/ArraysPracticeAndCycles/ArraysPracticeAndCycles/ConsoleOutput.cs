using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysPracticeAndCycles
{
    class ConsoleOutput
    {
        private readonly ConsoleWriter consoleWriter;
        private readonly Counting counting;
        public ConsoleOutput(ConsoleWriter pConsoleWriter, Counting pcounting)
        {
            consoleWriter = pConsoleWriter;
            counting = pcounting;
        }
        public void Output(string[] names, int[] ages, int incrementToAge)
        {
            consoleWriter.WriteText(Properties.Resources.ResultOutput + "\n", ConsoleColor.White);
            for (int index = 0; index < names.Length; index++)
            {
                consoleWriter.WriteText(Properties.Resources.Name, ConsoleColor.White);
                consoleWriter.WriteText(names[index], ConsoleColor.Yellow);
                consoleWriter.WriteText(Properties.Resources.OutputTextPrefix, ConsoleColor.White);
                consoleWriter.WriteText(counting.CountAge(ages[index], incrementToAge).ToString(), ConsoleColor.Green);
                Console.WriteLine();
            }
        }
    }
}
