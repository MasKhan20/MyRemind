using MyRemind.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyRemind.Data
{
    public class ReminderDataBase
    {
        readonly SQLiteAsyncConnection database;

        public ReminderDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Reminder>().Wait();
        }

        public Task<List<Reminder>> GetRemindersAsync()
        {
            return database.Table<Reminder>().ToListAsync();
        }

        public Task<Reminder> GetReminderAsync(int id)
        {
            return database.Table<Reminder>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveReminderAsync(Reminder reminder)
        {
            if (reminder.ID != 0)
            {
                return database.UpdateAsync(reminder);
            }
            else
            {
                return database.InsertAsync(reminder);
            }
        }

        public Task<int> DeleteReminderAsync(Reminder reminder)
        {
            return database.DeleteAsync(reminder);
        }
    }
}
