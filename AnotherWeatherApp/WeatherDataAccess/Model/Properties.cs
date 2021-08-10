using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class Properties
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timeseries")]
        public TimeData[] Timeseries { get; set; }
    }
}
