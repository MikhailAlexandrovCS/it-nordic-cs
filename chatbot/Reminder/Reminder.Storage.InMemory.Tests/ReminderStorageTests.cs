using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Remider.Storage.InMemory;
using Reminder.Storage.Core;

namespace TestReminderItemStorage
{
    [TestClass]
    public class RemiderStorageTests
    {
        [TestMethod]
        public void Constructor_Validly()
        {
            var expected = 0;

            var reminderStorage = new ReminderStorage();

            Assert.IsTrue(reminderStorage.StorageCount == expected);
        }

        [TestMethod]
        public void ReminderStorage_AddMethod_Validly()
        {
            var reminderStorage = new ReminderStorage();

            reminderStorage.Add(new ReminderItem(Guid.NewGuid(), DateTimeOffset.UtcNow, "1", "1"));

            Assert.IsTrue(reminderStorage.StorageCount != 0);
        }

        [TestMethod]
        public void ReminderStorage_AddMethod_Validly_ThrowingException()
        {
            var reminderStorage = new ReminderStorage();
            Guid guid = new Guid("B553C20A-8D24-4A91-97BD-8EDCF328130F");
            reminderStorage.Add(new ReminderItem(guid, DateTimeOffset.Parse("05/01/2008"), "1", "1"));

            Assert.ThrowsException<Exception>(() =>
            reminderStorage.Add(new ReminderItem(guid, DateTimeOffset.Parse("05/01/2008"), "1", "1")));
        }

        [TestMethod]
        public void ReminderStorage_GetMethod_Validly_ForNotNullResult()
        {
            var reminderStorage = new ReminderStorage();
            Guid guid = new Guid("B553C20A-8D24-4A91-97BD-8EDCF328130F");
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse("05/01/2008");
            string message = "1";
            string contactId = "1";
            ReminderItem expected = new ReminderItem(guid, dateTimeOffset, message, contactId);
            reminderStorage.Add(expected);

            ReminderItem actual = reminderStorage.Get(guid);

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void ReminderStorage_GetMethod_Validly_ForNullResult()
        {
            var reminderStorage = new ReminderStorage();

            ReminderItem actual = reminderStorage.Get(Guid.NewGuid());

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ReminderStorage_UpdateMethod_Validly()
        {
            var reminderStorage = new ReminderStorage();
            Guid guid = new Guid("B553C20A-8D24-4A91-97BD-8EDCF328130F");
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse("05/01/2008");
            string message = "1";
            string contactId = "1";
            ReminderItem expected = new ReminderItem(guid, dateTimeOffset, message, contactId);
            reminderStorage.Add(expected);
            expected.Message = "2";
            reminderStorage.Update(expected);

            var actual = reminderStorage.Get(expected.Id);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReminderStorage_UpdateMethod_Validly_ThrowException()
        {
            var reminderStorage = new ReminderStorage();
            Guid guid = new Guid("B553C20A-8D24-4A91-97BD-8EDCF328130F");
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse("05/01/2008");
            string message = "1";
            string contactId = "1";
            ReminderItem expected = new ReminderItem(guid, dateTimeOffset, message, contactId);

            Assert.ThrowsException<Exception>(() => reminderStorage.Update(expected));
        }
    }
}
