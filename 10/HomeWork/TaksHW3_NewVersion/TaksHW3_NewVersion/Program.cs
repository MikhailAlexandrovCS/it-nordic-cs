using System;

namespace TaksHW3_NewVersion
{
    class Program
    {
        private const int _maxPersonsValue = 3;

        static void Main(string[] args)
        {
            Person[] people = PeopleProvider.RequestFromConsole(_maxPersonsValue);
            PersonPresenter.ShowOnConsoleInfoAfterFourYears(people);
            Console.ReadKey();
        }
    }
}
