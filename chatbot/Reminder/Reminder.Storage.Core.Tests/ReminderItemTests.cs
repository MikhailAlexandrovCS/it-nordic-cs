using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Constructor_Validly_Sets_Id_Property()
		{
			// Preparing
			Guid expected = new Guid("BE1FFC61-E15D-4845-AD67-C9BA59A9F0E3");

			// Running
			var reminderItem = new ReminderItem(
				expected,
				DateTimeOffset.Now,
				null,
				null);

			// Checking
			Assert.AreEqual(expected, reminderItem.Id);
		}

		[TestMethod]
		public void Constructor_Validly_Sets_Date_Property()
		{
			// Preparing
			var expected = DateTimeOffset.Now;

			// Running
			var reminderItem = new ReminderItem(
				Guid.Empty,
				expected,
				null,
				null);

			// Checking
			Assert.AreEqual(expected, reminderItem.Date);
		}

		[TestMethod]
		public void TimeToSendTest()
		{
			// Preparing
			var time500ms = TimeSpan.FromMilliseconds(500);
			var reminderItem = new ReminderItem(
				Guid.Empty,
				DateTimeOffset.UtcNow + time500ms,
				null,
				null);

			var actual = reminderItem.TimeToSend;

			// Checking
			Assert.IsTrue(actual < time500ms); 
			Assert.IsTrue(actual > TimeSpan.Zero);
		}

		[TestMethod]
		public void TimeToSendTestIsLessThanZero()
		{
			// Preparing
			var reminderItem = new ReminderItem(
				Guid.Empty,
				DateTimeOffset.UtcNow - TimeSpan.FromDays(1),
				null,
				null);

			var actual = reminderItem.TimeToSend;

			// Checking
			Assert.IsTrue(actual < TimeSpan.Zero);
		}
	}
}
