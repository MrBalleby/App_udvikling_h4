using CurrentWeather.Views;
using CurrentWeather.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CurrentWeather.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public TimeModel TimeModel { get; set; }
        ObservableCollection<TimeModel> dates = new ObservableCollection<TimeModel>();
        public ObservableCollection<TimeModel> Dates { get { return dates; } }

        CultureInfo CultureInfo = new CultureInfo("da-DK");
        public LoginViewModel()
        {

            TimeModel = new TimeModel()
            {
                Date = DateTime.Now,
                ThisDayConverted = DateTime.Now.ToString("dd. MMMM yyyy", CultureInfo)
            };

            for (int i = 0; i < 6; i++)
            {
                dates.Add(new TimeModel()
                {
                    Date = DateTime.Now.AddDays(i),
                    ThisDayConverted = DateTime.Now.ToString("dd. MMMM yyyy", CultureInfo)
                });
            }
        }
    }
}
