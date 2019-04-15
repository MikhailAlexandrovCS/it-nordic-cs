using System;
using System.Collections.Generic;

namespace Singlton
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipeLogWriter multipeLogWriter = MultipeLogWriter.GetInstance(
                new List<ILogWriter> { ConsoleLogWriter.GetInstance(), FileLogWriter.GetInstance() });
            multipeLogWriter.LogError("Ошибка");
            multipeLogWriter.LogWarning("Внимание");
            multipeLogWriter.LogInfo("Информация");
            Console.ReadKey();
        }
    }
}
