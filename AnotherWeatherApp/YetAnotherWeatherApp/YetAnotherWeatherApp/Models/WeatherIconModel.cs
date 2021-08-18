using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherWeatherApp.Models
{
    public class WeatherIconModel
    {
        public string Code { get; set; }
        public string Description_en { get; set; }
        public string Description_da { get; set; }
        public string IconImage { get; set; }
    }
    public class WeatherIconEnum
    {
        public enum WeatherIconName
        {
            clearsky,
            cloudy,
            fair,
            fog,
            hevayrain,
            heavyrainandthunder,
            heavyrainshowers,
            heavyrainshowersandthunder,
            heavysleet,
            heavysleetandthunder,
            heavysleetshowers,
            heavysleetshowersandthunder,
            heavysnow,
            heavysnowandthunder,
            heavysnowshowers,
            heavysnowshowersandthunder,
            lightrain,
            lightrainandthunder,
            lightrainshowers,
            lightrainshowersandthunder,
            lightsleet,
            lightsleetandthunder,
            lightsleetshowers,
            lightsnow,
            lightsnowandthunder,
            lightsnowshowers,
            lightssleetshowersandthunder,
            lightssnowshowersandthunder,
            partlycloudy,
            rain,
            rainandthunder,
            rainshowers,
            rainshowersandthunder,
            sleet,
            sleetandthunder,
            sleetshowers,
            sleetshowersandthunder,
            snow,
            snowandthunder,
            snowshowers,
            snowshowersandthunder,
        }
    }
}
