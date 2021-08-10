using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherDataAccess.Model
{
    public class Units
    {
        [JsonProperty("air_pressure_at_sea_level")]
        public string AirPressureAtSeaLevel { get; set; }

        [JsonProperty("air_temperature")]
        public string AirTemperature { get; set; }

        [JsonProperty("cloud_area_fraction")]
        public string CloudAreaFraction { get; set; }

        [JsonProperty("precipitation_amount")]
        public string PrecipitationAmount { get; set; }

        [JsonProperty("relative_humidity")]
        public string RelativeHumidity { get; set; }

        [JsonProperty("wind_from_direction")]
        public string WindFromDirection { get; set; }

        [JsonProperty("wind_speed")]
        public string WindSpeed { get; set; }
    }
}
