using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyRemind.Views
{
    public class MainTabPage : TabbedPage
    {
        public MainTabPage()
        {
            Children.Add(new RemindersPage()
            {
                Title = "My reminders"
            });

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
