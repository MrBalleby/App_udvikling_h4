using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using YetAnotherWeatherApp.Views;

namespace YetAnotherWeatherApp.ViewModels
{
    public class NoteViewModel
    {
        public Command HomeCommand { get; }

        public NoteViewModel()
        {
            HomeCommand = new Command(OnDrawClicked);
        }
        private async void OnDrawClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
    }
}
