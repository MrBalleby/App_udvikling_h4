using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class TimeData
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
