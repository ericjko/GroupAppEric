﻿using System;
using System.Collections.Generic;
using GroupApp.ViewModels;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using GroupApp.Models;
using GroupApp.LoginPage;

namespace GroupApp
{
    public partial class MapsPage : ContentPage
    {
        //public bool IsShowingUser { get; set; }
        
        public MapsPage()
        {
            InitializeComponent();
            BindingContext = new PinItemsSourcePageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //shows user current location
            map.IsShowingUser = true;

            //moves map to location, zooms in on current location
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));

        }
        async void PinClicked(object sender, SelectedItemChangedEventArgs e)
        {
            Pin singlePin = sender as Pin;

            var groupdetailsPage = new GroupDetailsPage();
            groupdetailsPage.BindingContext = singlePin;

            await Navigation.PushAsync(groupdetailsPage);
        }

        //Add new Location
        async void OnGroupAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGroup((PinItemsSourcePageViewModel)BindingContext));
        }
        void LogOffClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }

        //Street, Satellite, Hybrid options
        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double zoomLevel = e.NewValue;
            double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
            if (map.VisibleRegion != null)
            {
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;
                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
            }
        }
    }
}
