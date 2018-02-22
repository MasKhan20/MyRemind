using MyRemind.ViewModels;
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
	public partial class CreateReminderPage : ContentPage
	{
		public CreateReminderPage()
		{
			InitializeComponent();
            BindingContext = new CreateReminderPageViewModel();

            MessagingCenter.Subscribe<CreateReminderPageViewModel, bool>(new CreateReminderPageViewModel(), "NewReminder",
                (sender, valid) =>
                {
                    if (valid == false)
                    {
                        DisplayAlert("Error", "Insufficient details have been supplied, \nPlease try again. ", "OK");//.Wait();
                        return;
                    }

                    DisplayAlert("Success", "Your reminder has been saved!", "OK");
                    Navigation.PopAsync();
                });
        }
	}
}