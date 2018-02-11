using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyRemind.Views
{
    public class MainMasterPage : MasterDetailPage
    {
        public MainMasterPage()
        {
            Master = new MenuPage()
            {
                Title = "MyRemind"
            };

            Detail = new NavigationPage(new MainTabPage());
        }
    }
}
