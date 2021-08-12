using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        ImageResourceExtension ImageResourceExtension = new ImageResourceExtension();
        public TimeModel TimeModel { get; set; }
        ObservableCollection<TimeModel> dates = new ObservableCollection<TimeModel>();
        public ObservableCollection<TimeModel> Dates { get { return dates; } }

        CultureInfo CultureInfo = new CultureInfo("da-DK");
        public HomeViewModel()
        {
            
            switch (BackgroundImageModel.WeatherTypes.clearsky)
            {
                case BackgroundImageModel.WeatherTypes.clearsky:
                    break;
                case BackgroundImageModel.WeatherTypes.cloudy:
                    break;
                case BackgroundImageModel.WeatherTypes.fair:
                    break;
                case BackgroundImageModel.WeatherTypes.fog:
                    break;
                case BackgroundImageModel.WeatherTypes.heavyrain:
                    break;
                case BackgroundImageModel.WeatherTypes.heavyrainandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.heavyrainshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.heavyrainshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysleet:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysleetandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysleetshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysleetshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysnow:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysnowandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysnowshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.heavysnowshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.lightrain:
                    break;
                case BackgroundImageModel.WeatherTypes.lightrainandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.lightrainshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.lightrainshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.lightsleet:
                    break;
                case BackgroundImageModel.WeatherTypes.lightsleetandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.lightsleetshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.lightsnow:
                    break;
                case BackgroundImageModel.WeatherTypes.lightsnowandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.lightsnowshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.lightssleetshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.lightssnowshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.partlycloudy:
                    break;
                case BackgroundImageModel.WeatherTypes.rain:
                    break;
                case BackgroundImageModel.WeatherTypes.rainandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.rainshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.rainshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.sleet:
                    break;
                case BackgroundImageModel.WeatherTypes.sleetandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.sleetshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.sleetshowersandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.snow:
                    break;
                case BackgroundImageModel.WeatherTypes.snowandthunder:
                    break;
                case BackgroundImageModel.WeatherTypes.snowshowers:
                    break;
                case BackgroundImageModel.WeatherTypes.snowshowersandthunder:
                    break;
                default:
                    break;
            }

            TimeModel = new TimeModel()
            {
                Date = DateTime.Now,
                ThisDayConverted = DateTime.Now.ToString("dd. MMMM yyyy", CultureInfo)
            };

            for (int i = 0; i < 6; i++)
            {
                dates.Add(new TimeModel()
                {
                    Date = DateTime.Now.AddDays(i),
                    ThisDayConverted = DateTime.Now.ToString("dd. MMMM yyyy", CultureInfo)
                });
            }
        }
    }
}
