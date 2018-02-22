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

        //private ObservableCollection<Reminder> _myReminders;
        //public ObservableCollection<Reminder> MyReminders => _myReminders 
        //    ?? (_myReminders = new ObservableCollection<Reminder>());

        public ObservableCollection<Reminder> MyReminders { get; set; } = new ObservableCollection<Reminder>();

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

        private async void UpdateListView()
        {
            MyReminders.Clear();

            List<Reminder> reminders = await App.DataBase.GetRemindersAsync();

            foreach (Reminder reminder in reminders)
            {
                MyReminders.Add(reminder);
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
            MessagingCenter.Send<RemindersPageViewModel>(this, "CreateReminder");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
