using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Remider.Storage.InMemory
{
	public class ReminderStorage : IRemainderStorage
	{
		private Dictionary<Guid, ReminderItem> _storage;

		public ReminderStorage()
		{
			_storage = new Dictionary<Guid, ReminderItem>();
		}

		void IRemainderStorage.Add(ReminderItem reminderItem)
		{
			/// TODO: add custom exception throwing if already exist
			_storage.Add(reminderItem.Id, reminderItem);
		}

		ReminderItem IRemainderStorage.Get(Guid id)
		{
			return _storage.ContainsKey(id) ? _storage[id] : null;
		}
		List<ReminderItem> IRemainderStorage.GetList(IEnumerable<RemainderItemStatus> status, int count, int startPosition)
		{
			throw new NotImplementedException();
		}

		void IRemainderStorage.Update(ReminderItem reminderItem)
		{
			/// TODO: add custom exception throwing if not found
			_storage[reminderItem.Id] = reminderItem;
		}
	}
}