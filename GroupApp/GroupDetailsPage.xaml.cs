using System;
using GroupApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Messaging;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Plugin.Geolocator;
using GroupApp.ViewModels;

namespace GroupApp
{
    public partial class GroupDetailsPage : ContentPage
    {
        private MapsPage _maps;
        public GroupDetailsPage(MapsPage maps)
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

            var singlePin = (CustomPin)BindingContext;


            //MarkerId test, User ID test
            await DisplayAlert($"{singlePin.MarkerId}", "User ID " + $"{singlePin.AutomationId}", "Ok");
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
    }
}
