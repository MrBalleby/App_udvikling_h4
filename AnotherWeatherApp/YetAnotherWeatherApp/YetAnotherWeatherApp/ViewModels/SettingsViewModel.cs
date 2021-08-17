using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YetAnotherWeatherApp.Views;

namespace YetAnotherWeatherApp.ViewModels
{
    public class SettingsViewModel
    {
        public Command LoginCommand { get; }

        public SettingsViewModel()
        {
            LoginCommand = new Command(OnDrawClicked);
        }

        private async void OnDrawClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(NoteView)}");
        }
    }
}
