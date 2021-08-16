using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.Services
{
    public class CityMapHandler : ClassMap<CityModel>
    {
        public CityMapHandler()
        {
            Map(m => m.Name).Name("city");
            Map(m => m.Lat).Name("lat");
            Map(m => m.Lot).Name("lng");
        }
        public static ObservableCollection<CityModel> GetCities()
        {
            DeviceStorageHandler deviceStorageHandler = new DeviceStorageHandler();
            deviceStorageHandler.LoadCityFile("dk.csv");
            return deviceStorageHandler.Content;            
        }
    }
}
