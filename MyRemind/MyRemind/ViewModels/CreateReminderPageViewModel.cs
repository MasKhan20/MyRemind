using MyRemind.Models;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private List<string> _remindTypes;
        public List<string> RemindTypes
        {
            get { return _remindTypes; }
            set
            {
                _remindTypes = value;
                RaisePropertyChanged(nameof(RemindTypes));
            }
        }

        private int _selectedRemindIndex = 0;
        public int SelectedRemindIndex
        {
            get { return _selectedRemindIndex; }
            set
            {
                _selectedRemindIndex = value;
                RaisePropertyChanged(nameof(SelectedRemindIndex));
                UpdateViews();
            }
        }

        #region Binding Properties Remind Types
        private bool _showDaily;
        public bool ShowDaily
        {
            get { return _showDaily; }
            set
            {
                _showDaily = value;
                RaisePropertyChanged(nameof(ShowDaily));
            }
        }

        private bool _showOnce;
        public bool ShowOnce
        {
            get { return _showOnce; }
            set
            {
                _showOnce = value;
                RaisePropertyChanged(nameof(ShowOnce));
            }
        }

        private bool _showWeekDays;
        public bool ShowWeekDays
        {
            get { return _showWeekDays; }
            set
            {
                _showWeekDays = value;
                RaisePropertyChanged(nameof(ShowWeekDays));
            }
        }

        private bool _showWeekEnds;
        public bool ShowWeekEnds
        {
            get { return _showWeekEnds; }
            set
            {
                _showWeekEnds = value;
                RaisePropertyChanged(nameof(ShowWeekEnds));
            }
        }

        private bool _showCustom;
        public bool ShowCustom
        {
            get { return _showCustom; }
            set
            {
                _showCustom = value;
                RaisePropertyChanged(nameof(ShowCustom));
            }
        }
        #endregion

        #region Binding Properties Custom Days
        private bool _customMon;
        public bool CustomMon
        {
            get { return _customMon; }
            set
            {
                _customMon = value;
                RaisePropertyChanged(nameof(CustomMon));
            }
        }

        private bool _customTue;
        public bool CustomTue
        {
            get { return _customTue; }
            set
            {
                _customTue = value;
                RaisePropertyChanged(nameof(CustomTue));
            }
        }

        private bool _customWed;
        public bool CustomWed
        {
            get { return _customWed; }
            set
            {
                _customWed = value;
                RaisePropertyChanged(nameof(CustomWed));
            }
        }

        private bool _customThu;
        public bool CustomThu
        {
            get { return _customThu; }
            set
            {
                _customThu = value;
                RaisePropertyChanged(nameof(CustomThu));
            }
        }

        private bool _customFri;
        public bool CustomFri
        {
            get { return _customFri; }
            set
            {
                _customFri = value;
                RaisePropertyChanged(nameof(CustomFri));
            }
        }

        private bool _customSat;
        public bool CustomSat
        {
            get { return _customSat; }
            set
            {
                _customSat = value;
                RaisePropertyChanged(nameof(CustomSat));
            }
        }

        private bool _customSun;
        public bool CustomSun
        {
            get { return _customSun; }
            set
            {
                _customSun = value;
                RaisePropertyChanged(nameof(CustomSun));
            }
        }
        #endregion

        public string ReminderTitle { get; set; }
        public string ReminderDescription { get; set; }

        public TimeSpan ReminderTimeOfDay;

        private DateTime _reminderDate;
        public DateTime ReminderDate
        {
            get { return _reminderDate; }
            set
            {
                _reminderDate = value;
                RaisePropertyChanged(nameof(ReminderDate));
            }
        }

        public INavigation Navigation { get; set; }

        public CreateReminderPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            RemindTypes = new List<string>()
            {
                "Daily",
                "Once",
                "Week Days",
                "Week Ends",
                "Custom Days",
            };

            ReminderDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            ReminderTimeOfDay = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            CustomFri = true;
        }

        private void UpdateViews()
        {
            ShowDaily = ShowOnce = ShowWeekDays = ShowWeekEnds = ShowCustom = false;
            switch (SelectedRemindIndex)
            {
                case 0:
                    ShowDaily = true;
                    break;
                case 1:
                    ShowOnce = true;
                    break;
                case 2:
                    ShowWeekDays = true;
                    break;
                case 3:
                    ShowWeekEnds = true;
                    break;
                case 4:
                    ShowCustom = true;
                    break;
                default:
                    break;
            }
        }

        private void SaveReminder_Command()
        {
            //validate
            bool valid = string.IsNullOrEmpty(ReminderTitle) ? false : true;

            var dueTime = new DateTime(ReminderDate.Year, ReminderDate.Month, ReminderDate.Day, ReminderTimeOfDay.Hours, ReminderTimeOfDay.Minutes, ReminderTimeOfDay.Seconds);
            var time = DateTime.Now;
            Reminder newReminder = new Reminder()
            {
                Title = ReminderTitle,
                Description = ReminderDescription,
                ActiveRemind = true,
                DueTime = dueTime
            };

            CrossLocalNotifications.Current.Show(newReminder.Title, newReminder.Description, newReminder.ID, DateTime.Now.AddMinutes(1));

            
            if (valid == false)
            {
                //DisplayAlert("Error", "Insufficient details have been supplied, \nPlease try again. ", "OK");//.Wait();
                return;
            }
 
            //DisplayAlert("Success", "Your reminder has been saved!", "OK");
            Navigation.PopAsync();
            

            if (valid == false)
                return;

            App.DataBase.SaveReminderAsync(newReminder);

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
