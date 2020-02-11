using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GroupApp
{
    public partial class MapsPage : ContentPage
    {
        public bool IsShowingUser { get; set; }

        public MapsPage()
        {
            InitializeComponent();

            
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
        //protected override async void OnAppearing()
        //{
        //    //Current Location
        //    base.OnAppearing();
        //    try
        //    {
        //        var request = new GeolocationRequest(GeolocationAccuracy.Medium);
        //        var location = await Geolocation.GetLocationAsync(request);

        //        if (location != null)
        //        {
        //            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        //        }
        //        Position position = new Position(location.Latitude, location.Longitude);
        //        MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);


        //        //Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map(mapSpan);
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Handle not supported on device exception
        //    }
        //    catch (FeatureNotEnabledException fneEx)
        //    {
        //        // Handle not enabled on device exception
        //    }
        //    catch (PermissionException pEx)
        //    {
        //        // Handle permission exception
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //    }
        //}


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
