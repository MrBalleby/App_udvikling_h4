using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherDataAccess.Data;
using Xamarin.CommunityToolkit.ObjectModel;
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
        public AsyncCommand GetDataFromApi { get; set; }
        public DailyWeatherSummaryView()
        {
            InitializeComponent();

            DateWeatherSummaryView.ItemsSource = dailyWeatherSummaries;

            GetDataFromApi = new AsyncCommand(OnGetDataFromApi);

            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today, AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(1), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(2), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(3), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
            dailyWeatherSummaries.Add(new DailyWeatherSummary { Date = DateTime.Today.AddDays(4), AirTemperature = GetRandomDouble(5, 40), IconName = RandomWeather() });
        }

        async Task OnGetDataFromApi()
        {
            var results = await new HTTPACCESS().GetWeatherFromLocationAsync(56.4520, 9.3963);

            var midDayResults = results.Properties.Timeseries.Where(ts => ts.Time.TimeOfDay == new TimeSpan(12, 0, 0)).ToList();
            foreach (var item in midDayResults)
            {
                dailyWeatherSummaries.Add(new DailyWeatherSummary { AirTemperature = item.Data.Instant.Details.AirTemperature, Date = item.Time, IconName = item.Data.NextSixHours.Summary.SymbolCode });
            }
        }

        void SetDailyWeatherFromTimeSeries(List<WeatherDataAccess.Model.TimeData> timeDatas)
        {
            foreach (var item in timeDatas)
            {
                dailyWeatherSummaries.Add(new DailyWeatherSummary { AirTemperature = item.Data.Instant.Details.AirTemperature, Date = item.Time, IconName = item.Data.NextHour.Summary.SymbolCode });
            }
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await OnGetDataFromApi();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            dailyWeatherSummaries.Clear();
        }
    }
}