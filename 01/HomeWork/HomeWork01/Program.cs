using System;
using System.Threading;

namespace HomeWork01
{
    class Program
    {
        private const int PAUSE = 5000;
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string userName = Console.ReadLine();
            Thread.Sleep(PAUSE);
            Console.WriteLine("Здравствуйте, " + userName + "!");
            Thread.Sleep(PAUSE);
            Console.WriteLine("До свидания, " + userName + "!");
            Console.ReadKey();
        }
    }
}
