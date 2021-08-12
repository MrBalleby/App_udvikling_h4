using System.ComponentModel;
using Xamarin.Forms;
using YetAnotherWeatherApp.ViewModels;

namespace YetAnotherWeatherApp.Views
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