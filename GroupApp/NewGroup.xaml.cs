using System;
using System.Collections.Generic;
using System.Linq;
using GroupApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using GroupApp.ViewModels;

namespace GroupApp
{
    public partial class NewGroup : ContentPage
    {

        public NewGroup()
        {
            
            InitializeComponent();
            
            BindingContext = new Pins();

        }
        async void onSaveAddressClick(object sender, EventArgs e)
        {
            var pins = (Pins)BindingContext;

            if (pins.Address != null && pins.Description != null)
            {
                Geocoder geoCoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(pins.Address);
            Position position = approximateLocations.FirstOrDefault();

            //gets latitude and longitude of address entered
            pins.Latitude = position.Latitude;
            pins.Longitude = position.Longitude;

            //pin created gets UserID
            pins.userID = App.getUserID();

            //pin created gets CategoryID; to filter pins by each category
            pins.categoryID = App.getCategoryID();

                //save Address,Details,Latitude,Longitude to database and observable list

            await Runtime.Locations.Save(pins);

            }
            else
            {
                await DisplayAlert("Error", "Missing Address or Description", "Ok");
            }

            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}
