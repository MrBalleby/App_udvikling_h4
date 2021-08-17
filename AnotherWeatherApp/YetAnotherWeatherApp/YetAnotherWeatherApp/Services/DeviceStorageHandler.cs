using CsvHelper;
using CsvHelper.Configuration;
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
                Content = new ObservableCollection<CityModel>();
                var libFolder = FileSystem.AppDataDirectory;
                using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var lines = reader.ReadToEnd().Split('\n');
                        foreach (string line in lines)
                        {
                            try
                            {
                                CityModel cityModel = new CityModel()
                                {
                                    Name = line.Split(';')[0] as string,
                                    Lat = line.Split(';')[1] as string,
                                    Lot = line.Split(';')[2].Replace("\r","") as string,
                                };
                                Content.Add(cityModel);
                            }
                            catch{}
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}