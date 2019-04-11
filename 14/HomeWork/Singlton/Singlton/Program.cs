using System;
using System.Collections.Generic;

namespace Singlton
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter consoleLogWriter = ConsoleLogWriter.GetInstance();
            FileLogWriter fileLogWriter = FileLogWriter.GetInstance(@"F:\testF.txt");
            List<ILogWriter> logWriters = new List<ILogWriter>()
            {
                consoleLogWriter,
                fileLogWriter
            };
            MultipeLogWriter multipeLogWriter = MultipeLogWriter.GetInstance(logWriters);
            multipeLogWriter.LogError(GetMessage(MessageType.Error, "Ошибка"));
            multipeLogWriter.LogWarning(GetMessage(MessageType.Warning, "Внимание"));
            multipeLogWriter.LogInfo(GetMessage(MessageType.Info, "Информация"));
            Console.ReadKey();
        }

        private static string GetMessage(MessageType messageType, string message)
        {
            return DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss+0000") + "\t" + messageType.ToString() + "\t" + message;
        }
    }
}
