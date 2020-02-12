using System;
using System.Collections.Generic;
using GroupApp.Models;
using Xamarin.Forms;

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
            
            await App.PinDatabase.SaveNoteAsync(pins);

            await Navigation.PopAsync();
        }
    }
}
