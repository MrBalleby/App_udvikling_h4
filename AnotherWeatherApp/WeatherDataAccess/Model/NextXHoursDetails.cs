using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class NextXHoursDetails
    {
        [JsonProperty("air_temperature_max")]
        public double? AirTemperatureMax { get; set; }

        [JsonProperty("air_temperature_min")]
        public double? AirTemperatureMin { get; set; }

        [JsonProperty("precipitation_amount")]
        public double? PrecipitationAmount { get; set; }

        [JsonProperty("precipitation_amount_max")]
        public double? PrecipitationAmountMax { get; set; }

        [JsonProperty("precipitation_amount_min")]
        public double? PrecipitationAmountMin { get; set; }

        [JsonProperty("probability_of_precipitation")]
        public double? ProbabilityOfPrecipitation { get; set; }

        [JsonProperty("probability_of_thunder")]
        public double? ProbabilityOfThunder { get; set; }
    }
}
