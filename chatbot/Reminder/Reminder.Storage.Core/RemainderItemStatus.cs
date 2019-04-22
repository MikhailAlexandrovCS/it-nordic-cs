using System;

namespace Reminder.Storage.Core
{
	public enum RemainderItemStatus
	{
		Awaiting,
		ReadyToSend,
		SuccessfullySent,
		Failed
	}
}