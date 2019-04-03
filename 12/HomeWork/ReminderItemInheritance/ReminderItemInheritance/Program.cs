using System;
using System.Collections.Generic;
using System.Globalization;

namespace ReminderItemInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ReminderItem> reminders = new List<ReminderItem>()
            {
                new ReminderItem(DateTimeOffset.Parse("01/04/2019 11:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Пора вставать!"),
                new ReminderItem(DateTimeOffset.Parse("01/04/2019 12:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Пора завтракать!"),
                new ReminderItem(DateTimeOffset.Parse("01/04/2019 23:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Пора ложиться спать!"),
                new PhoneReminderItem(DateTimeOffset.Parse("01/04/2019 12:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Позвонить на работу", "74991832756"),
                new PhoneReminderItem(DateTimeOffset.Parse("01/04/2019 19:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Позвонить в доставку", "749918327756"),
                new PhoneReminderItem(DateTimeOffset.Parse("01/04/2019 16:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Позвонить курьеру", "74991052756"),
                new ChatReminderItem(DateTimeOffset.Parse("31/03/2019 10:00", new CultureInfo("ru-RU").DateTimeFormat), 
                "Написать расписание", "Чат футбол", "MikhailAlexandrovCS"),
                new ChatReminderItem(DateTimeOffset.Parse("01/04/2019 12:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Опубликовать состав", "Чат футбол", "MikhailAlexandrovCS"),
                new ChatReminderItem(DateTimeOffset.Parse("01/04/2019 20:00", new CultureInfo("ru-RU").DateTimeFormat),
                "Подвести итоги игры", "Чат футбол", "MikhailAlexandrovCS"),
            };

            foreach(ReminderItem item in reminders)
            {
                item.WriteProperties();
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
    }
}
