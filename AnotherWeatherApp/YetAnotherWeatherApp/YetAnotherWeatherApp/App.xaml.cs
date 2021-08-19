using System;
using System.Diagnostics;
using WeatherDataAccess.Data;
using Xamarin.Essentials;
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
            AppActions.OnAppAction += AppActions_OnAppAction;
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IWeatherService, WeatherService>();
            MainPage = new AppShell();
        }

        //Application Actions - Not imlemented
        protected override async void OnStart()
        {
            try
            {
                await AppActions.SetAsync(
                    new AppAction("app_info", "App Info", icon: "app_info_action_icon"),
                    new AppAction("battery_info", "Battery Info"));
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine("App Actions not supported");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        void AppActions_OnAppAction(object sender, AppActionEventArgs e) //Ends in exception and does nothing
        {
            try
            {
                if (Application.Current != this && Application.Current is App app)
                {
                    AppActions.OnAppAction -= app.AppActions_OnAppAction;
                    return;
                }
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync($"//{e.AppAction.Id}");
                });
            }
            catch (Exception)
            {

            }
        }

    }
}
