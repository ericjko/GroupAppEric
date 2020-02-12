using System;
using System.Collections;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace GroupApp.ViewModels
{
    public class PinItemsSourcePageViewModel
    {
        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;

        public PinItemsSourcePageViewModel()
        {
            _locations = new ObservableCollection<Location>()
            {
                new Location("New York, USA", "The City That Never Sleeps", new Position(40.67, -73.94)),
                new Location("Los Angeles, USA", "City of Angels", new Position(34.11, -118.41)),
                new Location("San Francisco, USA", "Bay City", new Position(37.77, -122.45))
            };
        }
    }
}
