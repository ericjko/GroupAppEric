using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GroupApp
{
    public partial class GroupDetailsPage : ContentPage
    {
        public GroupDetailsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var singlePin = (Pin)BindingContext;

            //MarkerId test
            await DisplayAlert($"{singlePin.MarkerId}", $"{singlePin.Address}", "Ok");
        }
    }
}
