using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class NextXHoursSummary
    {
        [JsonProperty("symbol_code")]
        public string SymbolCode { get; set; }
    }
}
