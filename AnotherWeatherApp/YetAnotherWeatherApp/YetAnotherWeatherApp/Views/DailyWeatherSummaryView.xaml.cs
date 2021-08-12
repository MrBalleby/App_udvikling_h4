using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyWeatherSummaryView : ContentView
    {
        private static Random _random = new Random();

        private static string[] weathers = new string[]
        {
            "Clear",
            "Rainy",
            "Foggy",
            "Snow"
        };

        ObservableCollection<DailyWeatherSummary> dailyWeatherSummaries = new ObservableCollection<DailyWeatherSummary>();

        public DailyWeatherSummaryView()
        {
            InitializeComponent();

            DateWeatherSummaryView.ItemsSource = dailyWeatherSummaries;

            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today, AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(1), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(2), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(3), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(4), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
        }

        double GetRandomDouble(double min, double max)
        {
            var randomDouble = _random.NextDouble() * (max - min) + min;
            return Math.Round(randomDouble, 2);
        }

        string RandomWeather()
        {
            return weathers[_random.Next(weathers.Length - 1)];
        }

        public ObservableCollection<DailyWeatherSummary> DailyWeatherSummaries { get; set; }
    }
}