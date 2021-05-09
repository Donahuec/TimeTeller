using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TimeTeller.Models;

namespace TimeTeller.Data
{
    public class TimeTellerDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TimeTellerDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TimeEntry>().Wait();
            database.CreateTableAsync<TaskEntry>().Wait();
        }

        public Task<List<TimeEntry>> GetTimeEntriesAsync()
        {
            //Get all TimeEntries.
            return database.Table<TimeEntry>().ToListAsync();
        }

        public Task<List<TimeEntry>> GetTimeEntriesForTaskAsync(int taskId)
        {
            //Get all TimeEntries.
            return database.Table<TimeEntry>()
                           .Where(i => i.TaskId == taskId)
                           .ToListAsync();

        }

        public Task<TimeEntry> GetTimeEntryAsync(int id)
        {
            // Get a specific TimeEntry.
            return database.Table<TimeEntry>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTimeEntryAsync(TimeEntry timeEntry)
        {
            if (timeEntry.ID != 0)
            {
                // Update an existing TimeEntry.
                return database.UpdateAsync(timeEntry);
            }
            else
            {
                // Save a new TimeEntry.
                return database.InsertAsync(timeEntry);
            }
        }

        public Task<int> DeleteTimeEntryAsync(TimeEntry timeEntry)
        {
            // Delete a TimeEntry.
            return database.DeleteAsync(timeEntry);
        }

        public Task<List<TaskEntry>> GetTaskEntriesAsync()
        {
            //Get all TimeEntries.
            return database.Table<TaskEntry>().ToListAsync();
        }

        public Task<TaskEntry> GetTaskEntryAsync(int id)
        {
            // Get a specific TaskEntry.
            return database.Table<TaskEntry>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskEntryAsync(TaskEntry TaskEntry)
        {
            if (TaskEntry.ID != 0)
            {
                // Update an existing TaskEntry.
                return database.UpdateAsync(TaskEntry);
            }
            else
            {
                // Save a new TaskEntry.
                return database.InsertAsync(TaskEntry);
            }
        }

        public Task<int> DeleteTaskEntryAsync(TaskEntry TaskEntry)
        {
            // Delete a TaskEntry.
            return database.DeleteAsync(TaskEntry);
        }
    }
}