using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherWeatherApp.Models
{
    public class BackgroundImageModel
    {
        public enum WeatherTypes
        {
            clearsky,
            cloudy,
            fair,
            fog,
            heavyrain,
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
            snowshowersandthunder
        }

        private static BackgroundImageModel instance = null;
        public BackgroundImageModel() { }
        public static BackgroundImageModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BackgroundImageModel();
                }
                return instance;
            }
        }


        public object Image { get; set; }
        public string WeatherType { get; set; }
    }
}
