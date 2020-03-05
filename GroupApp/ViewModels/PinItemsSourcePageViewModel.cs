﻿using System;
using System.Collections;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using GroupApp.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace GroupApp.ViewModels
{

    public class PinItemsSourcePageViewModel
    {
        public ObservableCollection<CustomPin> _locations;

        //public ObservableCollection<Locations> _LocationsCreated;

        public IEnumerable Locations => _locations;

        //public IEnumerable LocationsCreated => _LocationsCreated;


        private EventHandler<PinClickedEventArgs> _clickFunction;



        public PinItemsSourcePageViewModel()
        {
            //to populate pins based on category
            int id = App.getCategoryID();
            

            //Location covPosition = new Location(52.407243, -1.503682);

            //Location warwickPosition = new Location(52.379413, -1.561481);

            //double miles = Location.CalculateDistance(covPosition, warwickPosition, DistanceUnits.Miles);

            //var UserPins = App.PinDatabase.GetPinsCreated(currentUserId);

            //Pins[] UserPins1 = UserPins.Result.ToArray();
            var pins = App.PinDatabase.GetNotesAsync(id);
            //List<Pins> result = pins.Result;
            Pins[] pins1 = pins.Result.ToArray();
            _locations = new ObservableCollection<CustomPin>()
            {
                //new Location(0,"New York, USA", "The City That Never Sleeps", new Position(40.67, -73.94)),
                //new Location(0,"Los Angeles, USA", "City of Angels", new Position(34.11, -118.41)),
                //new Location(0,"San Francisco, USA", "Bay City", new Position(37.77, -122.45))
            };

            
            for (int i = 0; i < pins1.Length; i++)
            {
                CustomPin pin = new CustomPin
                {
                    AutomationId = pins1[i].userID.ToString(),
                    Address = pins1[i].Address,
                    Label = pins1[i].Description,
                    Position = new Position(pins1[i].Latitude, pins1[i].Longitude),
                    
                };
                if (pins1[i].ImageData != null && pins1[i].ImageData.Length > 0)
                {
                    byte[] data = pins1[i].ImageData;
                    pin.ImageData=ImageSource.FromStream(()=>new MemoryStream(data));
                }
                pin.Group=pin.Label;
                pin.Url="https://"+pin.Group;
                pin.Name = App.UserDB.getUserById(App.getUserID()).ToString();
                
                _locations.Add(pin);
            }

           // for(int i = 0; i < UserPins1.Length; i++)
           // {
           //     _LocationsCreated.Add(new Locations(UserPins1[i].userID, UserPins1[i].Address, UserPins1[i].Description, new Position(UserPins1[i].Latitude, UserPins1[i].Longitude)));
           // }
            
            
        }
        public void SetDefaultClickFunction(EventHandler<PinClickedEventArgs> click_function)
        {
            if (_clickFunction != null)
            {
                foreach (CustomPin pin in _locations)
                {
                    try
                    {
                        pin.InfoWindowClicked -= _clickFunction;
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }
            _clickFunction = click_function;
            foreach (CustomPin pin in _locations)
            {
                pin.InfoWindowClicked += _clickFunction;
            }
        }

        public async Task Save(Pins pin)
        {
            await App.PinDatabase.SaveNoteAsync(pin); //adds to database, database will also update/add after checking if already exists.

            //First check if this is an edit or an add.
            CustomPin loc = _locations.FirstOrDefault(a => a.AutomationId == pin.ID.ToString());

            if (loc == null)
            {
                loc = new CustomPin
                {
                    AutomationId = pin.userID.ToString(),
                    Address = pin.Address,
                    Label = pin.Description,
                    Position = new Position(pin.Latitude, pin.Longitude)
                };

                _locations.Add(loc);
            }
            else
            {
                loc.Address = pin.Address;
                loc.Label = pin.Description;
                loc.Position = new Position(pin.Latitude, pin.Longitude);
            }
        }
        //to remove
        public async Task Remove(Pins pin)
        {
            await App.PinDatabase.DeleteNoteAsync(pin);
            CustomPin loc = _locations.FirstOrDefault(a => a.AutomationId == pin.ID.ToString());
            if (loc != null)
                _locations.Remove(loc);
        }
    }
}
