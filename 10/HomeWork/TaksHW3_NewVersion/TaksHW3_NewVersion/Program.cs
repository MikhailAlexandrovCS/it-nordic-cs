using System;

namespace TaksHW3_NewVersion
{
    class Program
    {
        private const int _maxPersonsValue = 3;

        static void Main(string[] args)
        {
            Person[] people = ValuesInputer.GetValues(_maxPersonsValue);
            ValuesOutputer.OutputInfoAfterFourYears(people);
            Console.ReadKey();
        }
    }
}
