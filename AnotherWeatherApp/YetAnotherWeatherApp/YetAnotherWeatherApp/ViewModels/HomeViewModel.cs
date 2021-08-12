using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YetAnotherWeatherApp.Models;

namespace YetAnotherWeatherApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        bool dayPickerIsVisible = false;
        public bool DayPickerIsVisible { 
            get => dayPickerIsVisible;
            set 
            {
                dayPickerIsVisible = value;
                OnPropertyChanged();
            } 
        }

        public ICommand ShowDayPicker { get; set; }
        public ICommand HideDayPicker { get; set; }

        public TimeModel TimeModel { get; set; }
        ObservableCollection<TimeModel> dates = new ObservableCollection<TimeModel>();
        public ObservableCollection<TimeModel> Dates { get { return dates; } }

        public HomeViewModel()
        {
            ShowDayPicker = new Command(OnShowDayPicker);
            HideDayPicker = new Command(OnHideDayPicker);
            TimeModel = new TimeModel()
            {
                Date = DateTime.Now,
            };

            for (int i = 0; i < 6; i++)
            {
                dates.Add(new TimeModel()
                {
                    Date = DateTime.Now.AddDays(i),
                });
            }
        }

        void OnShowDayPicker()
        {
            if (DayPickerIsVisible is false)
                DayPickerIsVisible = true;
        }

        void OnHideDayPicker()
        {
            if (DayPickerIsVisible is true)
                DayPickerIsVisible = false;
        }
    }
}
