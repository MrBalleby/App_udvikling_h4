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
        public ICommand ShowSearchList { get; set; }
        public ICommand OpenWebCommand { get; }
        public ICommand ShowDayPicker { get; set; }
        public ICommand HideDayPicker { get; set; }
        public AsyncCommand RefreshWeatherData { get; set; }

        public TimeModel TimeModel { get; set; }
        public ObservableCollection<TimeModel> Dates { get; } = new ObservableCollection<TimeModel>();
        public ObservableCollection<CityModel> Cities { get; } = new ObservableCollection<CityModel>();
        private ObservableCollection<CityModel> filteredItems;
        public ObservableCollection<CityModel> FilteredItems
        {
            get => filteredItems;
            set
            {
                // Notify property changed
            }
        }
        private string searchTerm;
        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                // Notify property changed
                SearchCommand.Execute(searchTerm);
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command<string>((searchString) =>
                {
                    FilteredItems = new ObservableCollection<CityModel>(Cities.Where(o => o.Name.ToLower().Contains(searchString.ToLower())));
                });
            }
        }
        public HomeViewModel()
        {
            Cities = CityMapHandler.GetCities();


            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.yr.no/en"));
            ShowSearchList = new Command(ControlShowSearchList);
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
                CurrentWeatherDetails = weatherData.Properties?.Timeseries.FirstOrDefault()?.Data?.Instant?.Details;
            }
        }

        void ControlShowSearchList()
        {
            if (controlShowSearchListIsVisible is false)
            {
                controlShowSearchListIsVisible = true;
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
