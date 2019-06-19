using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.ADO.Tests;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
	[TestClass]
	public class SqlReminderStorageTests
	{
		private const string _connectionString =
			@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Reminder;Integrated Security=true;";

		[TestInitialize]
		public void TestInitialize()
		{
			var dbInit = new SqlReminderStorageInit(_connectionString);
			dbInit.InitializeDatabase();
		}

        [TestMethod]
        public void Method_Property_Count_Returns_10_For_Initial_Data_Sets()
        {
            var storage = new SqlReminderStorage(_connectionString);

            int actual = storage.Count;

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void Method_Bulk()
        {
            var storage = new SqlReminderStorage(_connectionString);
            var ids = new List<Guid>()
            {
                new Guid("00000000-0000-0000-0000-222222222222"),
                new Guid("00000000-0000-0000-0000-111111111111")
            };
            storage.UpdateStatus(ids, ReminderItemStatus.Failed);
            var actual = storage.Get(ReminderItemStatus.Failed);

            Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[0]));
            Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[1]));
        }

        [TestMethod]
        public void Method_Remove_ReminderItem_By_Id()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Remove(Guid.Parse("00000000-0000-0000-0000-222222222222"));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Method_Remove_ReminderItem_By_Id_Return_False()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Remove(Guid.Parse("00000000-0000-0000-0000-222222222222"));
            actual = storage.Remove(Guid.Parse("00000000-0000-0000-0000-222222222222"));

            Assert.IsFalse(actual);
        }

        [TestMethod]
		public void Method_Add_Returns_Not_Empty_Guid()
		{
			var storage = new SqlReminderStorage(_connectionString);

			Guid actual = storage.Add(new Core.ReminderItemRestricted
			{
				ContactId = "TestContactId",
				Date = DateTimeOffset.Now.AddHours(1),
				Message = "Test Message",
				Status = Core.ReminderItemStatus.Awaiting
			});

			Assert.AreNotEqual(Guid.Empty, actual);
		}

        [TestMethod]
        public void Method_Get_By_Id_Returns_Just_Added_Item()
        {
            var storage = new SqlReminderStorage(_connectionString);

            DateTimeOffset expectedDate = DateTimeOffset.Now;
            string expectedContactId = "TestContactId";
            string expectedMessage = "TestMessageText";
            ReminderItemStatus expectedStatus = ReminderItemStatus.Awaiting;

            Guid id = storage.Add(new ReminderItemRestricted
            {
                ContactId = expectedContactId,
                Date = expectedDate,
                Message = expectedMessage,
                Status = expectedStatus

            });

            Assert.AreNotSame(Guid.Empty, id);

            var actualItem = storage.Get(id);

            Assert.IsNotNull(actualItem);
            Assert.AreEqual(id, actualItem.Id);
            Assert.AreEqual(expectedContactId, actualItem.ContactId);
            Assert.AreEqual(expectedDate, actualItem.Date);
            Assert.AreEqual(expectedMessage, actualItem.Message);
            Assert.AreEqual(expectedStatus, actualItem.Status);
        }

        [TestMethod]
        public void Method_Get_By_Id_Returns_Null_If_Not_Found()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(Guid.Empty);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Method_Get_List_Reminders_By_Status()
        {
            var storage = new SqlReminderStorage(_connectionString);

            int expectedCountAwaiting = 2;

            var actualItemAwaiting = storage.Get(ReminderItemStatus.Awaiting);



            Assert.AreEqual(expectedCountAwaiting, actualItemAwaiting.Count);

        }

        [TestMethod]
        public void Method_Get_List_Reminders_By_Status0()
        {
            var storage = new SqlReminderStorage(_connectionString);



            int expectedCountSent = 2;

            var actualItemSent = storage.Get(ReminderItemStatus.Sent);





            Assert.AreEqual(expectedCountSent, actualItemSent.Count);

        }

        [TestMethod]
        public void Method_Get_List_Reminders_By_Status1()
        {
            var storage = new SqlReminderStorage(_connectionString);



            int expectedCountFailed = 2;

            var actualItemFailed = storage.Get(ReminderItemStatus.Failed);



            Assert.AreEqual(expectedCountFailed, actualItemFailed.Count);
        }

        [TestMethod]
        public void Method_Update_Status_By_Guid()
        {
            var storage = new SqlReminderStorage(_connectionString);

            storage.UpdateStatus(Guid.Parse("00000000-0000-0000-0000-444444444444"), ReminderItemStatus.Ready);

            var actualItemReady = storage.Get(ReminderItemStatus.Ready);
            var expectedItemReady = 1;

            Assert.AreEqual(expectedItemReady, actualItemReady.Count);
        }



    }
}
