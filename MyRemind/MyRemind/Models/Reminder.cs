using System;
using System.Collections.Generic;
using System.Text;

namespace MyRemind.Models
{
    public class Reminder
    {
        public enum ReminderType
        {
            AllDay,
            Daily,
            Once,
            WeekDays,
            WeekEnds,
            Weekly
        };
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueTime { get; set; }
        public bool ActiveRemind { get; set; }
    }
}
