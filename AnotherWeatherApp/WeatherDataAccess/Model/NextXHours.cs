using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class NextXHours
    {
        [JsonProperty("summary")]
        public NextXHoursSummary Summary { get; set; }

        [JsonProperty("details")]
        public NextXHoursDetails Details { get; set; }
    }
}
