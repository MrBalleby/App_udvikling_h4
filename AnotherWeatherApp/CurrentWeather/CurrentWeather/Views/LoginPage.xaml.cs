using CurrentWeather.Models;
using CurrentWeather.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrentWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private ObservableCollection<TimeModel> timeList;
        private CultureInfo CultureInfo = new CultureInfo("da-DK");
        public ObservableCollection<TimeModel> TimeList
        {
            get
            {
                if (timeList.First().Date != DateTime.Now)
                {
                    timeList.RemoveAt(0);
                    timeList.Add(new TimeModel() { Date = DateTime.Now.AddDays(6),
                        ThisDayConverted = DateTime.Now.ToString("dd. MMMM yyyy", CultureInfo) 
                    });
                }
                return timeList; 
            }
        }

        
        
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        protected void OnButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = true;
        }
        protected void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }
        protected void OnOkButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }


    }
}