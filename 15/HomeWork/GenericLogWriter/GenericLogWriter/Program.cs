using System;
using System.Collections.Generic;

namespace GenericLogWriter
{
    class Program
    {
        private static string _path = @"F:\testF.txt";

        static void Main(string[] args)
        {
            LogWriterFactory logWriterFactory = LogWriterFactory.GetInstance();
            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            FileLogWriter fileLogWriter = new FileLogWriter(_path);
            MultipeLogWriter multipeLogWriter = new MultipeLogWriter
                (new List<ILogWriter>()
                { logWriterFactory.GetLogWriter<ILogWriter>(consoleLogWriter),
                logWriterFactory.GetLogWriter<ILogWriter>(fileLogWriter)});
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
