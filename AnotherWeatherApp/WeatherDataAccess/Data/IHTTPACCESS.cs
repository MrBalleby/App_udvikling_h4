using System.Threading.Tasks;
using WeatherDataAccess.Model;

namespace WeatherDataAccess.Data
{
    public interface IHTTPACCESS
    {
        Task<WeatherData> GetWeatherFromLocationAsync(double lat, double lon);
    }
}