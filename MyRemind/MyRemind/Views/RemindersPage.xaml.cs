using MyRemind.Models;
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
	public partial class RemindersPage : ContentPage
	{
		public RemindersPage()
		{
			InitializeComponent();
            BindingContext = new RemindersPageViewModel();
		}

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Reminder;
            if (item == null)
                return;

            await Navigation.PushAsync(new ReminderDetailPage(new ReminderDetailPageViewModel(item)));

            // Manually deselect item.
            RemindersListView.SelectedItem = null;
        }
    }
}