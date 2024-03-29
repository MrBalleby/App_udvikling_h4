﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YetAnotherWeatherApp.ViewModels;

namespace YetAnotherWeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedWeatherView : ContentPage
    {
        public DetailedWeatherView()
        {
            InitializeComponent();
            this.BindingContext = new DetailedWeatherViewModel();
        }
    }
}