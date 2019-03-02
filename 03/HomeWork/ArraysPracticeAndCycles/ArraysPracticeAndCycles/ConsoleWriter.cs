using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace ArraysPracticeAndCycles
{
    class ConsoleWriter
    {
        private readonly ConsoleChangeColor consoleChangeColor;
        public ConsoleWriter(CultureInfo cultureInfo, ConsoleChangeColor pconsoleChangeColor)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            consoleChangeColor = pconsoleChangeColor;
        }
        public void WriteText(string message, ConsoleColor color)
        {
            consoleChangeColor.SetConsoleColor(color);
            Console.Write(message);
        }
    }
}
