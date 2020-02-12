using System;
using System.Collections.Generic;
using System.Linq;
using GroupApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GroupApp
{
    public partial class NewGroup : ContentPage
    {
        public NewGroup()
        {
            InitializeComponent();
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

            //saves Address,Details,Latitude,Longitude to database
            await App.PinDatabase.SaveNoteAsync(pins);

            await Navigation.PopAsync();
        }
    }
}
