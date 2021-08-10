using CurrentWeather.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CurrentWeather.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}