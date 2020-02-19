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
        private PinItemsSourcePageViewModel _collection;

        public NewGroup(PinItemsSourcePageViewModel collection)
        {
            _collection = collection;
            InitializeComponent();
            
            BindingContext = new Pins();

        }
        async void onSaveAddressClick(object sender, EventArgs e)
        {
            var pins = (Pins)BindingContext;
            Geocoder geoCoder = new Geocoder();

            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(pins.Address);
            Position position = approximateLocations.FirstOrDefault();

            //gets latitude and longitude of address entered
            pins.Latitude = position.Latitude;
            pins.Longitude = position.Longitude;

            //pin created gets UserID
            pins.userID = App.getUserID();

            //save Address,Details,Latitude,Longitude to database and observable list
            await _collection.Save(pins);

            await Navigation.PopAsync();
        }
    }
}
