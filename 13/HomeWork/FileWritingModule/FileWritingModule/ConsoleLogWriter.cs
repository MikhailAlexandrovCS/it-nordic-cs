using System;
using System.Collections.Generic;
using System.Text;

namespace FileWritingModule
{
    class ConsoleLogWriter : AbstractLogWriter
    {
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
    }
}
