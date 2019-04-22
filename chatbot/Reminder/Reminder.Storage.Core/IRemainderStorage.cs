using System;
using System.Collections.Generic;

namespace Reminder.Storage.Core
{
	public interface IRemainderStorage
	{
		/// <summary>
		/// Adds new reminder item
		/// </summary>
		void Add(ReminderItem reminderItem);
		/// <summary>
		/// Updates existing reminder item
		/// </summary>
		void Update(ReminderItem reminderItem);
		/// <summary>
		/// Returns reminder item by guid_id
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		ReminderItem Get(Guid id);
		List<ReminderItem> GetList(IEnumerable<RemainderItemStatus> status, int count, int startPosition);
	}
}