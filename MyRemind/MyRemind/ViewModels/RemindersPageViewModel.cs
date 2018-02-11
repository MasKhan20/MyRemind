using MyRemind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyRemind.ViewModels
{
    public class RemindersPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ICommand RefreshRemindersCommand => new Command(RefreshReminders_Command);
        public ICommand NewReminderCommand => new Command(NewReminder_Command);

        public ObservableCollection<Reminder> MyReminders { get; set; }// = new ObservableCollection<Reminder>();

        private bool _isRemindersRefreshing = false;
        public bool IsRemindersRefreshing
        {
            get { return _isRemindersRefreshing; }
            set
            {
                _isRemindersRefreshing = value;
                RaisePropertyChanged(nameof(IsRemindersRefreshing));
            }
        }

        private Reminder _selectedReminder;
        public Reminder SelectedReminder
        {
            get { return _selectedReminder; }
            set
            {
                _selectedReminder = value;
                RaisePropertyChanged(nameof(SelectedReminder));
            }
        }
        #endregion

        public RemindersPageViewModel()
        {
            UpdateListView();
        }

        private void UpdateListView()
        {
            MyReminders = new ObservableCollection<Reminder>();

            for (int i = 1; i < 21; i++)
            {
                var newItem = new Reminder()
                {
                    Title = $"Remind task {i}",
                    Description = $"This is the item description for Remind task {i}, clicking on this item in the ListView will take you to a new page where you can view and/or edit the reminder. "
                };

                newItem.ActiveRemind = i % 2 == 0 ? true : false;

                MyReminders.Add(newItem);
            }
        }

        private void RefreshReminders_Command()
        {
            IsRemindersRefreshing = true;

            UpdateListView();
            
            IsRemindersRefreshing = false;
        }

        /// <summary>
        /// This is currently unused as we will be getting data from the code-behind
        /// </summary>
        private void OnReminderSelected_Command()
        {
            //empty
        }

        private void NewReminder_Command()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
