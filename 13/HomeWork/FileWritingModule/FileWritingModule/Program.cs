using System;
using System.Collections.Generic;

namespace FileWritingModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter(@"F:\testF.txt");
            var consoleLogWriter = new ConsoleLogWriter();
            List<ILogWriter> logWriters = new List<ILogWriter>();
            logWriters.Add(consoleLogWriter);
            logWriters.Add(fileLogWriter);
            MultipeLogWriter multipeLogWriter = new MultipeLogWriter(logWriters);
            multipeLogWriter.LogError(GetMessage(MessageType.Error, "Ошибка"));
            multipeLogWriter.LogWarning(GetMessage(MessageType.Warning, "Внимание"));
            multipeLogWriter.LogInfo(GetMessage(MessageType.Info, "Информация"));
            Console.ReadLine();
        }

        private static string GetMessage(MessageType messageType, string message)
        {
            return DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss+0000") + "\t" + messageType.ToString() + "\t" + message;
        }
    }
}
