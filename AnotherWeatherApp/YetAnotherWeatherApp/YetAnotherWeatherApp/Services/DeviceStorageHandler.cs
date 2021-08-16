using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace YetAnotherWeatherApp.Services
{
    public class DeviceStorageHandler
    {

        public async void LoadFile(string fileName)
        {
            var libFolder = FileSystem.AppDataDirectory;
            using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var fileContents = await reader.ReadToEndAsync();
                    System.Diagnostics.Debug.WriteLine(fileContents);
                }
            }
        }
    }
}
