using MyRemind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRemind.ViewModels
{
    public class ReminderDetailPageViewModel
    {
        public Reminder Reminder { get; set; }
        public ReminderDetailPageViewModel(Reminder reminder = null)
        {
            
            Reminder = reminder;
        }
    }
}
