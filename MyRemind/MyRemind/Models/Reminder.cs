using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRemind.Models
{
    public class Reminder
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public ReminderTypes ReminderType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueTime { get; set; }
        public bool ActiveRemind { get; set; }

        //public static List<Reminder> Reminders = new List<Reminder>();
    }
}
