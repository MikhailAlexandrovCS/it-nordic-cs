using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Remider.Storage.InMemory
{
	public class ReminderStorage : IRemainderStorage
	{
		private Dictionary<Guid, ReminderItem> _storage;

        public int StorageCount => _storage.Count;

        public ReminderStorage()
		{
			_storage = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem reminderItem)
		{
            if (!_storage.ContainsKey(reminderItem.Id))
                _storage.Add(reminderItem.Id, reminderItem);
            else
                throw new Exception("Такое оповещение уже есть!");
		}

		public ReminderItem Get(Guid id)
		{
			return _storage.ContainsKey(id) ? _storage[id] : null;
		}

		public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> status, int count, int startPosition)
		{
            List<ReminderItem> reminderItems = new List<ReminderItem>();
            //foreach (KeyValuePair<Guid, ReminderItem> keyValuePair in _storage)
            //    if (keyValuePair.Value.status.ToString() == status.ToString())
            //        reminderItems.Add(keyValuePair.Value);
            return reminderItems;
		}

		public void Update(ReminderItem reminderItem)
		{
            if (_storage.ContainsKey(reminderItem.Id))
                _storage[reminderItem.Id] = reminderItem;
            else
                throw new Exception("Такого напоминания не существует!");
		}
	}
}