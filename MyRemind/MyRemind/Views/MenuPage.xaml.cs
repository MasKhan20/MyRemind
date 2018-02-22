using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRemind.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
		}

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateReminderPage());
        }

        private void ViewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RemindersPage());
        }

        
    }
}