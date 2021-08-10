using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentWeather.Models
{
    public class TimeModel
    {
        public DateTime ThisDay { get; set; }
        public DateTime MinDay { get; set; }
        public DateTime MaxDay { get; set; }
        public string ThisDayConverted { get; set; }
    }
}
