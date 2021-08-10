using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class Instant
    {
        [JsonProperty("details")]
        public InstantDetails Details { get; set; }
    }
}
