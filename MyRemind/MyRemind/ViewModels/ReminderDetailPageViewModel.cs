using MyRemind.Data;
using MyRemind.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyRemind.ViewModels
{
    public class ReminderDetailPageViewModel
    {
        public ICommand DeleteReminderCommand => new Command(DeleteReminder_Command);

        public Reminder Reminder { get; set; }
        public ReminderDetailPageViewModel(Reminder reminder = null)
        {
            
            Reminder = reminder;
        }

        private void DeleteReminder_Command()
        {
            App.DataBase.DeleteReminderAsync(Reminder);
        }
    }
}
