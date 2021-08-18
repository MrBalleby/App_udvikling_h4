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
        public Command DrawCommand { get; }
        public Command HomeCommand { get; }

        public SettingsViewModel()
        {
            DrawCommand = new Command(OnDrawClicked);
            HomeCommand = new Command(OnHomeClicked);
        }

        private async void OnDrawClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(NoteView)}");
        }
        private async void OnHomeClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
    }
}
