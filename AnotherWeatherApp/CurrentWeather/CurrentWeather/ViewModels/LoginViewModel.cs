using CurrentWeather.Views;
using CurrentWeather.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace CurrentWeather.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public TimeModel TimeModel { get; set; }
        CultureInfo CultureInfo = new CultureInfo("da-DK");
        public LoginViewModel()
        {
            TimeModel = new TimeModel()
            {
                ThisDay = DateTime.Now,
                MinDay = DateTime.Now.AddDays(-1),
                MaxDay = DateTime.Now.AddDays(6),
                ThisDayConverted = DateTime.Now.ToString("dd. MMMM yyyy", CultureInfo)
            };
        }
    }
}
