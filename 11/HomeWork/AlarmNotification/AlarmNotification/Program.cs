using System;
using System.Globalization;

namespace AlarmNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem firstAlarm = new ReminderItem(DateTimeOffset.Parse("01/04/2019 10:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Пора вставать!");
            firstAlarm.WriteProperties();

            ReminderItem secondAlarm = new ReminderItem(DateTimeOffset.Parse("31/03/2019 17:31", new CultureInfo("ru-RU").DateTimeFormat),
                "Дневной сон окончен!");
            secondAlarm.WriteProperties();
            Console.ReadLine();
        }
    }
}
