using CsvHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.Services
{
    public class DeviceStorageHandler
    {
        public ObservableCollection<CityModel> Content { get; set; }
        public async void LoadCityFile(string fileName)
        {
            try
            {
                var libFolder = FileSystem.AppDataDirectory;
                using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Context.RegisterClassMap<CityMapHandler>();
                            var records = csv.GetRecords<CityModel>();
                            foreach (var item in records)
                            {
                                Content.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
