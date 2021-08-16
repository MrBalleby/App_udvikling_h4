using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WeatherDataAccess.Model;

namespace WeatherDataAccess.Data
{
    public class HTTPACCESS
    {
        private static string _baseUrl = @"https://api.met.no/weatherapi/locationforecast/2.0/compact";

        /// <summary>
        /// Get weather from a specific location, using coordinates
        /// </summary>
        /// <param name="lat">Latitude of the coordinate</param>
        /// <param name="lon">Lonitude of the coordinate</param>
        /// <returns></returns>
        public async Task<WeatherData> GetWeatherFromLocationAsync(double lat, double lon)
        {
            using (var httpClient = new HttpClient()) 
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");

                var uriBuilder = new UriBuilder(_baseUrl);

                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["lat"] = lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                query["lon"] = lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
                uriBuilder.Query = query.ToString();

                var test = uriBuilder.ToString();

                using (var response = await httpClient.GetAsync(uriBuilder.ToString()))
                {

                    if (response.IsSuccessStatusCode is false)
                        return new WeatherData { StatusCode = response.StatusCode };

                    var responseBody = await response.Content.ReadAsStringAsync();

                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver()
                    };

                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody, settings);
                    weatherData.StatusCode = response.StatusCode;

                    return weatherData;
                }
            }
        }
    }
}
