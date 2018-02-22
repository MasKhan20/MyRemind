using MyRemind.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyRemind.ViewModels
{
    public class CreateReminderPageViewModel : INotifyPropertyChanged
    {
        public ICommand SaveReminderCommand => new Command(SaveReminder_Command);

        //private Reminder _title;
        //public Reminder Title
        //{
        //    get { return _title; }
        //    set
        //    {
        //        _title = value;
        //        RaisePropertyChanged(nameof(Title));
        //    }
        //}

        public string Title { get; set; }
        public string Description { get; set; }

        public CreateReminderPageViewModel()
        {
            DateTime dateTime = new DateTime();
        }

        private void SaveReminder_Command()
        {
            //validate
            bool valid = string.IsNullOrEmpty(Title) ? false : true;

            Reminder newReminder = new Reminder()
            {
                Title = Title,
                Description = Description
            };

            App.DataBase.SaveReminderAsync(newReminder);


            /* Exception is thrown  */
            MessagingCenter.Send(this, "NewReminder", valid);
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}
