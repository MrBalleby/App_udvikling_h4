using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public TimeModel TimeModel { get; set; }
        ObservableCollection<TimeModel> dates = new ObservableCollection<TimeModel>();
        public ObservableCollection<TimeModel> Dates { get { return dates; } }

        CultureInfo CultureInfo = new CultureInfo("da-DK");
        public HomeViewModel()
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
