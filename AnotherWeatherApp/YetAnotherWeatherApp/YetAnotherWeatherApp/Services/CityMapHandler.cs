using CsvHelper.Configuration;
using System.Collections.ObjectModel;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.Services
{
    public class CityMapHandler : ClassMap<CityModel>
    {
        public static ObservableCollection<CityModel> GetCities()
        {
            DeviceStorageHandler deviceStorageHandler = new DeviceStorageHandler();
            deviceStorageHandler.LoadCityFile("dk.csv");
            return deviceStorageHandler.Content;            
        }
    }
}
