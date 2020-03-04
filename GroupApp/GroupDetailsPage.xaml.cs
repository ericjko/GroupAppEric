﻿using System;
using GroupApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Messaging;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Plugin.Geolocator;
using GroupApp.ViewModels;
using System.IO;

namespace GroupApp
{
    public partial class GroupDetailsPage : ContentPage
    {
        //private MapsPage _maps;
        public GroupDetailsPage(MapsPage maps)
        {
            InitializeComponent();
            BindingContext = new CustomPin();
            var pin = (CustomPin)BindingContext;
        }
        void OnJoinButtonClicked(object sender, EventArgs e)
        {
            var singlePin = (Pin)BindingContext;
            //nuget package predefined method to send email
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            User user = App.UserDB.getUserById(Int16.Parse(singlePin.AutomationId));
            string email = user.Email;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(email);
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var singlePin = (CustomPin)BindingContext;

            int currentUserId = App.getUserID();
            if (currentUserId == Int16.Parse(singlePin.AutomationId))
            {
                DeleteButton.IsEnabled = true;
            }

            //MarkerId test, User ID test
            await DisplayAlert($"{singlePin.MarkerId}", "User ID " + $"{singlePin.AutomationId}", "Ok");

            image.Source = ImageSource.FromStream(() => new MemoryStream(singlePin.ImageData));

        }

        public async void NavigateButtonClicked(object sender, EventArgs e)
        {
            var singlePin = (Pin)BindingContext;
            
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            Xamarin.Essentials.Map.OpenAsync(position.Latitude, position.Longitude, new MapLaunchOptions
            {
                Name = singlePin.Address,
                NavigationMode = NavigationMode.Walking
            });
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var pins = (Pin)BindingContext;
        }
        async private void OnChatClicked(object sender, EventArgs e)
        {
            var singlePin = (CustomPin)BindingContext;
            //var pin = Runtime.Locations;
            //singlePin.Name = pin.Locations.GetType().Name;
            User user = App.UserDB.getUserById(Int16.Parse(singlePin.AutomationId));


            App.setUserName(user.Name);
            App.setUserGroup(singlePin.Group);
            
            var chatPage = new ChatPage();
            

            await Navigation.PushAsync(chatPage);

        }

    }
}
