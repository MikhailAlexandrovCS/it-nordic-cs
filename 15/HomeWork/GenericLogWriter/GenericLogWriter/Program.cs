using System;
using System.Collections.Generic;

namespace GenericLogWriter
{
    class Program
    {
        private static string _path = @"F:\testF.txt";

        static void Main(string[] args)
        {
            MultipeLogWriter multipeLogWriter = (MultipeLogWriter)LogWriterFactory.GetInstance().GetLogWriter<MultipeLogWriter>(
                new List<ILogWriter> {
                (ConsoleLogWriter)LogWriterFactory.GetInstance().GetLogWriter<ConsoleLogWriter>(null),
                (FileLogWriter)LogWriterFactory.GetInstance().GetLogWriter<FileLogWriter>(_path)});
            multipeLogWriter.LogError("Ошибка");
            multipeLogWriter.LogWarning("Внимание");
            multipeLogWriter.LogInfo("Информация");
            Console.ReadKey();
        }

        
    }
}
