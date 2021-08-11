using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentWeather.Models
{
    public class DailyWeatherSummary
    {
        public DateTime Date { get; set; }
        public string IconName { get; set; }
        public double AirTemperature { get; set; }
    }
}
