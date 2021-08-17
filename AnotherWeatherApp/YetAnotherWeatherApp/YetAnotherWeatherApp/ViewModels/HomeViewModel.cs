using YetAnotherWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YetAnotherWeatherApp.Models;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using YetAnotherWeatherApp.Views;

namespace YetAnotherWeatherApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private WeatherDataAccess.Model.InstantDetails currentWeatherDetails;
        public WeatherDataAccess.Model.InstantDetails CurrentWeatherDetails
        {
            get => currentWeatherDetails;
            set
            {
                currentWeatherDetails = value;
                OnPropertyChanged();
            }
        }
        WeatherIconModel currentWeatherIconModel = new WeatherIconModel { Description_da = "Sikkert godt vejr", Description_en = "Probably nice weather" };
        public WeatherIconModel CurrentWeatherIconModel
        {
            get => currentWeatherIconModel;
            set
            {
                currentWeatherIconModel = value;
                OnPropertyChanged();
            }
        }
        private bool controlShowSearchListIsVisible = false;
        private bool dayPickerIsVisible = false;
        public bool DayPickerIsVisible
        {
            get => dayPickerIsVisible;
            set
            {
                dayPickerIsVisible = value;
                OnPropertyChanged();
            }
        }
        public ICommand OpenWebCommand { get; set; }
        public ICommand ShowDayPicker { get; set; }
        public ICommand HideDayPicker { get; set; }
        public AsyncCommand RefreshWeatherData { get; set; }

        public TimeModel TimeModel { get; set; }
        public ObservableCollection<TimeModel> Dates { get; } = new ObservableCollection<TimeModel>();

        
        public HomeViewModel()
        {
            OpenWebCommand = new Command(async () => await Shell.Current.GoToAsync($"//{nameof(SettingsView)}"));
            ShowDayPicker = new Command(OnShowDayPicker);
            HideDayPicker = new Command(OnHideDayPicker);

            RefreshWeatherData = new AsyncCommand(OnRefreshWeatherData);
            TimeModel = new TimeModel()
            {
                Date = DateTime.Now,
            };

            for (int i = 0; i < 6; i++)
            {
                Dates.Add(new TimeModel()
                {
                    Date = DateTime.Now.AddDays(i),
                });
            }
        }

        async Task OnRefreshWeatherData()
        {
            var location = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();

            var weatherData = await new WeatherDataAccess.Data.HTTPACCESS().GetWeatherFromLocationAsync(location.Latitude, location.Longitude);

            if (weatherData != null)
            {
                var timeData = weatherData.Properties?.Timeseries.FirstOrDefault();
                CurrentWeatherDetails = timeData?.Data?.Instant?.Details;
                
                if (WeatherIconList == null || WeatherIconList.Count == 0)
                    await LoadWeatherIconList.ExecuteAsync();

                if (WeatherIconList.Any(wi => wi.Code == timeData?.Data?.Icon))
                    CurrentWeatherIconModel = WeatherIconList.First(wi => wi.Code == timeData.Data.Icon);
            }
        }

        
        void OnShowDayPicker()
        {
            if (DayPickerIsVisible is false)
            {
                DayPickerIsVisible = true;
            }
        }

        void OnHideDayPicker()
        {
            if (DayPickerIsVisible is true)
            {
                DayPickerIsVisible = false;
            }
        }
    }
}
