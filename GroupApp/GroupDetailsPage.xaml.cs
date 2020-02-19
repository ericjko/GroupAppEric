using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using GroupApp.Data;
using GroupApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Messaging;

namespace GroupApp
{
    public partial class GroupDetailsPage : ContentPage
    {
        public GroupDetailsPage()
        {
            InitializeComponent();
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

            var singlePin = (Pin)BindingContext;

            //MarkerId test, User ID test
            await DisplayAlert($"{singlePin.MarkerId}", "User ID " + $"{singlePin.AutomationId}", "Ok");
        }
    }
}
