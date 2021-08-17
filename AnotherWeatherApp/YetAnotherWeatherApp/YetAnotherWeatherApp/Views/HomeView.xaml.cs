﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YetAnotherWeatherApp.Models;
using YetAnotherWeatherApp.Services;
using YetAnotherWeatherApp.ViewModels;

namespace YetAnotherWeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
            citylist.IsVisible = false;
        }

        //Dynamic ItemList for city search
        private ObservableCollection<CityModel> Cities = new ObservableCollection<CityModel>();
        CityModel city = new CityModel();
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                Cities = CityMapHandler.GetCities();
                citylist.BeginRefresh();
                citylist.IsVisible = true;
                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    citylist.ItemsSource = Cities;
                else
                    citylist.ItemsSource = Cities.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                citylist.EndRefresh();
            }
        }

        private void citylist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            city = e.SelectedItem as CityModel;
            searchbar.Text = city.Name;
            citylist.IsVisible = false;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            citylist.IsVisible = false;
        }
    }
}