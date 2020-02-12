using System;
using System.Collections.Generic;
using GroupApp.ViewModels;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using GroupApp.Models;


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

            //new pin Locations
            

            var newPinPosition = await App.PinDatabase.GetNotesAsync();
        }
        async void OnGroupAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGroup
            {
                BindingContext = new Pins()
            });
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
