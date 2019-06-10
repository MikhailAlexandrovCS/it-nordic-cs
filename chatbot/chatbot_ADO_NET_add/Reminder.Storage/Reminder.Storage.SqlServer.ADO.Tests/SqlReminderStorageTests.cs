using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    

    [TestClass]
    public class SqlReminderStorageTests
    {
        private const string connectionString = @"Data Source=localhost;Initial Catalog=ReminderTests;Integrated Security=true";

        [TestInitialize]
        public void TestInitialize()
        {
            (new SqlReminderStorageInit(connectionString)).InitalizeDatabse();
        }

        [TestMethod]
        public void Method_Add_Returns_Not_Empty_Guid()
        {
            SqlServerReminderStorage sqlServerReminderStorage = new SqlServerReminderStorage(connectionString);

            Guid actual = sqlServerReminderStorage.Add(new Core.ReminderItemRestricted
            {
                ContactId = "TestContact",
                Date = DateTimeOffset.Now.AddHours(1),
                Message = "testMessage",
                Status = Core.ReminderItemStatus.Awaiting
            });

            Assert.AreNotEqual(Guid.Empty, actual);
        }
    }
}
