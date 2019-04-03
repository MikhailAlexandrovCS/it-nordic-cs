using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItemInheritance
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }

        public TimeSpan TimeToAlarm
        {
            get
            {
                return DateTimeOffset.Now.Subtract(AlarmDate);
            }
        }

        public bool isOutdated
        {
            get
            {
                return TimeToAlarm.Milliseconds >= 0 ? true : false;
            }
        }

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public virtual void WriteProperties()
        {
            Console.Write($"Тип данных: {GetType()}\n" +
                $"Время и дата будильника: {AlarmDate.ToString("dd/MM/yyyy HH:mm")}\n" +
                $"Сообщение будильника: {AlarmMessage}\n" +
                $"Время до срабатывания будильника: " +
                $"{(!isOutdated ? $"{Math.Abs(TimeToAlarm.Hours)}:{Math.Abs(TimeToAlarm.Minutes)}:{Math.Abs(TimeToAlarm.Seconds)}" : "00:00:00")}\n" +
                $"Статус будильника: {(isOutdated ? "Просрочен" : "Не просрочен")}\n");
        }
    }
}