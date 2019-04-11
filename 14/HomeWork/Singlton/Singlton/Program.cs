using System;

namespace Singlton
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipeLogWriter multipeLogWriter = MultipeLogWriter.GetInstance(); 
            Console.ReadKey();
        }
    }
}
