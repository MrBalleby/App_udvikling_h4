using System;
using System.Threading.Tasks;
using WeatherDataAccess;

namespace WeatherDataAccessConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpAccess = new WeatherDataAccess.Data.HTTPACCESS();

            var response = await httpAccess.GetWeatherFromLocationAsync(56.4520, 9.3963);

            Console.WriteLine("Hello World!");
        }
    }
}
