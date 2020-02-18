using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using GroupApp.Models;

namespace GroupApp.ViewModels
{
    public class PinItemsSourcePageViewModel
    {
        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;

        public PinItemsSourcePageViewModel()
        {
            var pins = App.PinDatabase.GetNotesAsync();
            //List<Pins> result = pins.Result;
            Pins[] pins1 = pins.Result.ToArray();
            _locations = new ObservableCollection<Location>()
            {
                new Location(0,"New York, USA", "The City That Never Sleeps", new Position(40.67, -73.94)),
                new Location(0,"Los Angeles, USA", "City of Angels", new Position(34.11, -118.41)),
                new Location(0,"San Francisco, USA", "Bay City", new Position(37.77, -122.45))
            };
            for (int i = 0; i < pins1.Length; i++)
            {
                _locations.Add(new Location(pins1[i].userID, pins1[i].Address, pins1[i].Description, new Position(pins1[i].Latitude, pins1[i].Longitude)));
            }
            
        }

        public async Task Save(Pins pin)
        {
            await App.PinDatabase.SaveNoteAsync(pin); //mpiva: I don't know if this updates or add automagically. if not, the database update/add should be after checking if already exists, below.

            //mpiva: First we check if this is an edit or an add.
            Location loc = _locations.FirstOrDefault(a => a.AutomationID == pin.ID);
            if (loc == null)
            {
                loc=new Location(pin.ID,pin.Address,pin.Description,new Position(pin.Latitude,pin.Longitude));
                _locations.Add(loc);
            }
            else
            {
                loc.Address = pin.Address;
                loc.Description = pin.Description;
                loc.Position=new Position(pin.Latitude,pin.Longitude);
            }
        }
        public async Task Remove(Pins pin)
        {
            await App.PinDatabase.DeleteNoteAsync(pin);
            Location loc = _locations.FirstOrDefault(a => a.AutomationID == pin.ID);
            if (loc != null)
                _locations.Remove(loc);
        }
    }
}
