using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace YetAnotherWeatherApp.Models
{
    public class TimeModel
    {
        CultureInfo _cultureInfo = new CultureInfo("da-DK");

        public DateTime Date { get; set; }
        public string ThisDayConverted { get => Date.ToString("dd. MMMM yyyy", _cultureInfo); }

        public string Weekday { get => Date.DayOfWeek.ToString(); }

        public string ThisDayConvertedWithWeekday { get => $"{Weekday}\t{ThisDayConverted}"; }
    }
}
