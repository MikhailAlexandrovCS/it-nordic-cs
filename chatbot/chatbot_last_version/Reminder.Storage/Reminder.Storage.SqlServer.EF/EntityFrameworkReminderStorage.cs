using Microsoft.EntityFrameworkCore;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.EF.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Reminder.Storage.SqlServer.EF
{
    public class EntityFrameworkReminderStorage : IReminderStorage
    {
        public static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider(
                    (category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information,
                        true
                    )
            });

        private readonly DbContextOptionsBuilder<ReminderStorageContext> _builder;

        public EntityFrameworkReminderStorage(string connectionString, bool enableLogging = false)
        {
            _builder = new DbContextOptionsBuilder<ReminderStorageContext>()
                .UseSqlServer(connectionString);
            if(enableLogging)
            {
                _builder
                    .UseLoggerFactory(MyConsoleLoggerFactory)
                    .EnableSensitiveDataLogging(true);
            }
        }

        public int Count
        {
            get
            {
                using (var context = new ReminderStorageContext(_builder.Options))
                {
                    return context.ReminderItem.Count();
                }
            }
        }

        public Guid Add(ReminderItemRestricted reminder)
        {
            var dto = new ReminderItemDto(reminder);

            using (var context = new ReminderStorageContext(_builder.Options))
            {
                context.Add(dto);
                context.SaveChanges();
                return dto.Id;
            }
        }

        public ReminderItem Get(Guid id)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                return context.ReminderItem
                    .FirstOrDefault(ri => ri.Id == id)
                    ?.ToReminderItem();
            }
        }

        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                if (count == 0 && startPostion == 0)
                {
                    return context.ReminderItem
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                if (count == 0 && startPostion != 0)
                {
                    return context.ReminderItem
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                return context.ReminderItem
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Take(count)
                        .Select(r => r.ToReminderItem())
                        .ToList();
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                if (count == 0 && startPostion == 0)
                {
                    return context.ReminderItem
                        .Where(ri => ri.Status.Equals(status))
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                if(count == 0 && startPostion != 0)
                {
                    return context.ReminderItem
                        .Where(ri => ri.Status.Equals(status))
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                return context.ReminderItem
                    .Where(ri => ri.Status.Equals(status))
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Take(count)
                        .Select(r => r.ToReminderItem())
                        .ToList();
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var dtos = context.ReminderItem
                    .Where(ri => ri.Status.Equals(status))
                    .Select(ri => ri.ToReminderItem())
                    .ToList();

                return dtos;
            }
        }

        public bool Remove(Guid id)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminder = context.ReminderItem.FirstOrDefault(ri => ri.Id.Equals(id));
                if (reminder == null)
                    return false;
                context.ReminderItem.Remove(reminder);
                context.SaveChanges();
                return true;
            }
        }

        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {

            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminderItems = context.ReminderItem.Where(ri => ids.Contains(ri.Id)).ToList();
                foreach (var dto in reminderItems)
                {
                    dto.Status = status;
                }
                context.SaveChanges();
            }
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminderItem = context.ReminderItem.FirstOrDefault(ri => ri.Id.Equals(id));
                reminderItem.Status = status;
                context.SaveChanges();
            }
        }
    }
}
