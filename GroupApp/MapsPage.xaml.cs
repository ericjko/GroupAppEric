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
    public partial class MapsPage : TabbedPage
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
            //var locator = CrossGeolocator.Current;
            //var position = await locator.GetPositionAsync();
          
            

            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            Position southwestBound = new Position(17.418652, 78.327941);
            Position northeastBound = new Position(17.439288, 78.354593);
            //Coventry University position

            Position covPosition = new Position(52.407243, -1.503682);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(covPosition, Distance.FromMiles(0.7)));

            //For pin list
            //int catid = App.getCategoryID();
            //listView.ItemsSource = await App.PinDatabase.GetNotesAsync(catid);


        }
        async void PinClicked(object sender, SelectedItemChangedEventArgs e)
        {
            Pin singlePin = sender as Pin;

            var groupdetailsPage = new GroupDetailsPage(new MapsPage());
            groupdetailsPage.BindingContext = singlePin;

            await Navigation.PushAsync(groupdetailsPage);
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Locations loc = e.SelectedItem as Locations;
            if (loc != null)
            {
                Pin singlePin = map.Pins.FirstOrDefault(a => a.AutomationId == loc.AutomationID.ToString());
                if (singlePin != null)
                {
                    var groupdetailsPage = new GroupDetailsPage(new MapsPage());
                    groupdetailsPage.BindingContext = singlePin;

                    await Navigation.PushAsync(groupdetailsPage);
                }
            }
        }



        ////Add new Location
        //async void OnGroupAddedClicked(object sender, EventArgs e)
        //{

        //    await Navigation.PushAsync(new NewGroup());

        //}
        //void LogOffClicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new NavigationPage(new Login());
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

        
        //public async Task Navigate(Pin pin)
        //{
        //    //await App.PinDatabase.DeleteNoteAsync(pin);
        //    //LocationViewModel loc = _locations.FirstOrDefault(a => a.AutomationID == pin.ID);
        //    //if (loc != null)
        //    //    _locations.Remove(loc);
        //    //var locator = CrossGeolocator.Current;
        //    //var position = await locator.GetPositionAsync();
        //    //Xamarin.Essentials.Map.OpenAsync(position.Latitude, position.Longitude, new MapLaunchOptions
        //    //{
        //    //    Name = pin.Address,
        //    //    NavigationMode = NavigationMode.Walking
        //    //});
        //}
    }
}
