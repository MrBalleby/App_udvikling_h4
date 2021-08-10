using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherDataAccess.Model
{
    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        public double? Longitude 
        { 
            get
            {
                double? lon = null;

                if (Coordinates is not null && Coordinates.Length > 2)
                {
                    lon = Coordinates[0];
                }

                return lon;
            }
        }

        public double? Latitude
        {
            get
            {
                double? lat = null;

                if (Coordinates is not null && Coordinates.Length > 2)
                {
                    lat = Coordinates[1];
                }

                return lat;
            }
        }
    }
}
