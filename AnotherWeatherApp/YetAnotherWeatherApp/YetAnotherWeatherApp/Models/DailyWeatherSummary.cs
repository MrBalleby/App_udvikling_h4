﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherWeatherApp.Models
{
    public class DailyWeatherSummary
    {
        public DateTimeOffset Date { get; set; }
        public string IconName { get; set; }
        public double AirTemperature { get; set; }
    }
}
