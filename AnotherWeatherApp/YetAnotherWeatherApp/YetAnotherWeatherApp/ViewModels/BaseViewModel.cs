using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;

using YetAnotherWeatherApp.Models;
using YetAnotherWeatherApp.Services;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Essentials;

namespace YetAnotherWeatherApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            LoadWeatherIconList = new AsyncCommand(OnLoadWeatherIconList);
        }

        List<CityModel> cityList = new List<CityModel>();
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        List<WeatherIconModel> weatherIconList = new List<WeatherIconModel>();
        public List<WeatherIconModel> WeatherIconList
        {
            get => weatherIconList;
            set
            {
                weatherIconList = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand LoadWeatherIconList { get; set; }

        async Task OnLoadWeatherIconList()
        {
            string filename = "WeatherIcon.json";

            using (var stream = await Xamarin.Essentials.FileSystem.OpenAppPackageFileAsync(filename))
            {
                using (var reader = new StreamReader(stream))
                {
                    var fileContents = await reader.ReadToEndAsync();

                    var result = JsonConvert.DeserializeObject<WeatherIconList>(fileContents);
                    WeatherIconList = result.WhetherIconList;
                }
            }
        }

        public GeoLocationModel GeoLocation { get; set; }
        protected void LocationService()
        {
            using (Task<GeoLocationModel> task = GeoLocationHandler.GetCorrdinatesAsync())
            {
                task.Start();
                GeoLocation = task.Result;
                task.Dispose();
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
