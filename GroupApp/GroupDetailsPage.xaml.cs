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

            //MarkerId test, User ID test
            await DisplayAlert($"{singlePin.MarkerId}", "User ID " + $"{singlePin.AutomationId}", "Ok");
        }
    }
}
