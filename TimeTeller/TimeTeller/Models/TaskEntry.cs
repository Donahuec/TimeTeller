using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTeller.Models
{
    public class TaskEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
