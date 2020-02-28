using System;
using System.Collections.Generic;
using System.Linq;
using GroupApp.ViewModels;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using GroupApp.Models;
using GroupApp.LoginPage;
using System.Threading.Tasks;

namespace GroupApp
{
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage()
        {
            
            BindingContext = new ProfilePageViewModel();
            InitializeComponent();

            int currentUserId = App.getUserID();

            User currentUser = App.UserDB.getUserById(currentUserId);

            UserNameLabel.Text = currentUser.Name;
        }

        /*async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Locations loc = e.SelectedItem as Locations;
            if (loc != null)
            {
                CustomPin singlePin = Runtime.cMap.CustomPins.FirstOrDefault(a => a.AutomationId == loc.AutomationID.ToString());
                if (singlePin != null)
                {
                    var groupdetailsPage = new GroupDetailsPage(new MapsPage());
                    groupdetailsPage.BindingContext = singlePin;

                    await Navigation.PushAsync(groupdetailsPage);
                }
            }
        }*/
    }
}
