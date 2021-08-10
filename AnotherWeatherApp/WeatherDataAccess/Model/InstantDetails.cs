using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class InstantDetails
    {
        [JsonProperty("air_pressure_at_sea_level")]
        public double AirPressureAtSeaLevel { get; set; }

        [JsonProperty("air_temperature")]
        public double AirTemperature { get; set; }

        [JsonProperty("cloud_area_fraction")]
        public double CloudAreaFraction { get; set; }

        [JsonProperty("relative_humidity")]
        public double RelativeHumidity { get; set; }

        [JsonProperty("wind_from_direction")]
        public double WindFromDirection { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
    }
}
