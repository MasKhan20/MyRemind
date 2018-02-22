using MyRemind.Data;
using MyRemind.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyRemind
{
	public partial class App : Application
	{
        static ReminderDataBase database;

		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MenuPage());
            //new NavigationPage().BarBackgroundColor = Color.LimeGreen;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static ReminderDataBase DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new ReminderDataBase(
                        DependencyService.Get<IFileHelper>().GetLocalFilePath("ReminderSQLite.db3"));
                }
                return database;
            }
        }
	}
}
