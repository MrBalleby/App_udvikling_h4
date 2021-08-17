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

        private bool cityListIsVissible = false;
        public bool CityListIsVissible
        {
            get => cityListIsVissible;
            set
            {
                cityListIsVissible = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand ShowCityListIsVissible { get; set; }
        public ICommand HideCityListIsVissible { get; set; }
        public ICommand ShowDayPicker { get; set; }
        public ICommand HideDayPicker { get; set; }
        public AsyncCommand RefreshWeatherData { get; set; }

        public TimeModel TimeModel { get; set; }
        public ObservableCollection<TimeModel> Dates { get; } = new ObservableCollection<TimeModel>();


        #region SearchBar
        public ObservableCollection<CityModel> Cities { get; } = new ObservableCollection<CityModel>();
        private ObservableCollection<CityModel> filteredItems;
        public ObservableCollection<CityModel> FilteredItems
        {
            get => filteredItems;
            set
            {
                filteredItems = value;
                OnPropertyChanged();
            }
        }
        private string searchTerm;
        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                SearchCommand.Execute(searchTerm);
                OnPropertyChanged();
            }
        }

        public Command SearchCommand
        {
            get
            {
                OnShowCityListIsVissible();
                return new Command<string>((searchString) =>
                {
                    FilteredItems = new ObservableCollection<CityModel>(Cities.Where(o => o.Name.ToLower().Contains(searchString.ToLower())));
                });
            }
        }
        void OnShowCityListIsVissible()
        {
            if (CityListIsVissible is false)
            {
                CityListIsVissible = true;
            }
        }
        void OnHideCityListIsVissible()
        {
            if (CityListIsVissible is true)
            {
                CityListIsVissible = false;
            }
        }
        #endregion
        public HomeViewModel()
        {
            Cities = CityMapHandler.GetCities();
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.yr.no/en"));
            ShowCityListIsVissible = new Command(OnShowCityListIsVissible);
            HideCityListIsVissible = new Command(OnHideCityListIsVissible);
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
