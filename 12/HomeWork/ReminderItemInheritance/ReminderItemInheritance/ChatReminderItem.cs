using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItemInheritance
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }

        public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string chatName, string accountName)
            : base(alarmDate, alarmMessage)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties()
        {
            Console.Write($"Тип данных: {GetType()}\n" +
                $"Время и дата: {AlarmDate.ToString("dd/MM/yyyy HH:mm")}\n" +
                $"Сообщение: {AlarmMessage}\n" +
                $"Статус отправки: {(isOutdated ? "Отправлено" : "Не отправлено")}\n" +
                $"Имя чата: {ChatName}\n" +
                $"Имя аккаунта: {AccountName}");
        }
    }
}
