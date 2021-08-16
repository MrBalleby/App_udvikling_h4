using DeviceOrientation.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

using YetAnotherWeatherApp.Models;
using YetAnotherWeatherApp.Services;
using static YetAnotherWeatherApp.Services.DeviceOrientationHandler;

namespace YetAnotherWeatherApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
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
        private void SearchCommandExecute()
        {
            

            //var tempRecords = CityModel.Where(c => c.FullName.Contains(Text));
            //Customers = new ObservableCollection<Customer>(tempRecords);
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

        protected Orientation SetDeviceOrientation()
        {
            Orientation orientation = new Orientation();
            MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
            {
                switch (message.Orientation)
                {
                    case DeviceOrientations.Undefined:
                        orientation = Orientation.None;
                        break;
                    case DeviceOrientations.Landscape:
                        orientation = Orientation.Landscape;
                        break;
                    case DeviceOrientations.Portrait:
                        orientation = Orientation.Portrait;
                        break;
                    default:
                        orientation = Orientation.None;
                        break;
                }
            });
            return orientation;
        }
        protected void StopDeviceOrientation()
        {
            MessagingCenter.Unsubscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId);
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
