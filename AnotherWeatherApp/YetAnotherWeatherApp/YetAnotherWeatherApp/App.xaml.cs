using System;
using WeatherDataAccess.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YetAnotherWeatherApp.Services;
using YetAnotherWeatherApp.Views;

namespace YetAnotherWeatherApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IWeatherService, WeatherService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
