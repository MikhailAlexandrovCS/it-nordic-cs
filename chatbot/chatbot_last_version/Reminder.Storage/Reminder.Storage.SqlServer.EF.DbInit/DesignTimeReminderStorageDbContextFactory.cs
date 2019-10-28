﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reminder.Storage.SqlServer.EF.Context;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reminder.Storage.SqlServer.EF.DbInit
{
    public class DesignTimeReminderStorageDbContextFactory : IDesignTimeDbContextFactory<ReminderStorageContext>
    {

        public ReminderStorageContext CreateDbContext(string[] args)
        {
            string connectionString = ConnectionStringFactory.GetDbConnectionString();
            var migrationAssembly = typeof(Program)
                .GetTypeInfo()
                .Assembly.GetName()
                .Name;

            var builder = new DbContextOptionsBuilder<ReminderStorageContext>();
            builder.UseSqlServer(connectionString, 
                ob => ob.MigrationsAssembly(migrationAssembly));

            return new ReminderStorageContext(builder.Options);
        }
    }
}
