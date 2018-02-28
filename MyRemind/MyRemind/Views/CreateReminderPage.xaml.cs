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

            BindingContext = new CreateReminderPageViewModel(Navigation);

            
        }
	}
}