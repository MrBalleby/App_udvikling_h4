using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAccess.Model
{
    public class WeatherDataSingleton
    {
        private static WeatherDataSingleton instance = null;
        public WeatherDataSingleton() { }

        public static WeatherDataSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherDataSingleton();
                }
                return instance;
            }
        }

        public static void Reset()
        {
            instance = null;
        }

        public WeatherData WeatherData;

    }
}
