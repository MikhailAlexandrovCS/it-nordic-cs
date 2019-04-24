using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Model;
using Reminder.Storage.InMemory;
using System;
using System.Threading;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTest
	{
		[TestMethod]
		public void Check_That_Reminder_Calls_Internal_Delegate()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);

			bool delegateWasFalse = false;

			reminderDomain.SendReminder += (reminder) =>
			{
				delegateWasFalse = true;
			};

			reminderDomain.Add(new AddReminderModel
			{
				Date = DateTimeOffset.Now
			});

			reminderDomain.Run();

			Thread.Sleep(2000);

			Assert.IsTrue(delegateWasFalse);
		}

		[TestMethod]
		public void Check_That_On_Exception_SendReminder_SendingFailed_Event()
		{
			var reminderStorage = new ReminderStorage();
			var reminderDomain = new ReminderDomain(reminderStorage);
			bool eventHandlerCalled = false;

			reminderDomain.SendReminder += (reminder) =>
			{
				throw new Exception();
			};

			reminderDomain.SendingFailedEvent += (s, e) =>
			{
				eventHandlerCalled = true;
			};

			reminderDomain.Add(new AddReminderModel
			{
				Date = DateTimeOffset.Now
			});

			reminderDomain.Run();

			Thread.Sleep(2000);

			Assert.IsTrue(eventHandlerCalled);
		}
	}
}
