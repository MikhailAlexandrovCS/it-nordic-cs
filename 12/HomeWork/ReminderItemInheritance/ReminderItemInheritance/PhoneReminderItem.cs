using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItemInheritance
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber)
            : base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties()
        {
            Console.Write($"Тип данных: {GetType()}\n" +
                $"Время и дата: {AlarmDate.ToString("dd/MM/yyyy HH:mm")}\n" +
                $"Сообщение: {AlarmMessage}\n" +
                $"Статус: {(isOutdated ? "Пропущен" : "Не пропущен")}\n" +
                $"Номер телефона: {PhoneNumber}");
        }
    }
}
