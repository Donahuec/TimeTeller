using System;
using SQLite;

namespace TimeTeller.Models
{
    public class TimeEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int TaskId { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime RecordedTime { get; set; }
    }
}