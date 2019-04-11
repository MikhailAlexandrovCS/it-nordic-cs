using System;
using System.Collections.Generic;
using System.Text;

namespace Singlton
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        private static ConsoleLogWriter _consoleLogWriter;

        private ConsoleLogWriter() { }

        public override void LogError(string message)
        {
            Console.Write($"{message}\n");
        }

        public override void LogInfo(string message)
        {
            Console.Write($"{message}\n");
        }

        public override void LogWarning(string message)
        {
            Console.Write($"{message}\n");
        }

        public static ConsoleLogWriter GetInstance()
        {
            if (_consoleLogWriter == null)
                _consoleLogWriter = new ConsoleLogWriter();
            return _consoleLogWriter;
        }
    }
}
