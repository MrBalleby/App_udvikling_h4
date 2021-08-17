using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class Data
    {
        [JsonProperty("instant")]
        public Instant Instant { get; set; }

        [JsonProperty("next_1_hours")]
        public NextXHours NextHour { get; set; }

        [JsonProperty("next_6_hours")]
        public NextXHours NextSixHours { get; set; }

        [JsonProperty("next_12_hours")]
        public NextXHours NextTwelveHours { get; set; }

        public string Icon
        {
            get
            {
                if (NextHour?.Summary != null)
                    return NextHour.Summary.SymbolCode;

                if (NextSixHours?.Summary != null)
                    return NextSixHours.Summary.SymbolCode;

                if (NextTwelveHours?.Summary != null)
                    return NextTwelveHours.Summary.SymbolCode;

                return string.Empty;
            }
        }
    }
}
