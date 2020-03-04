using System;
using System.Collections.Generic;
using System.Text;
using GroupApp.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using System.Collections;

namespace GroupApp.ViewModels
{
    public class ProfilePageViewModel
    {
        public ObservableCollection<CustomPin> _LocationsCreated;

        public IEnumerable LocationsCreated => _LocationsCreated;

        public ProfilePageViewModel()
        {
            int currentUserId = App.getUserID();

            var UserPins = App.PinDatabase.GetPinsCreated(currentUserId);

            Pins[] UserPins1 = UserPins.Result.ToArray();

            _LocationsCreated = new ObservableCollection<CustomPin>();

            for (int i = 0; i < UserPins1.Length; i++)
            {
                CustomPin pin = new CustomPin
                {
                    AutomationId = UserPins1[i].userID.ToString(),
                    Address = UserPins1[i].Address,
                    Label = UserPins1[i].Description,
                    Position = new Position(UserPins1[i].Latitude, UserPins1[i].Longitude)
                };
                _LocationsCreated.Add(pin);
            }
        }
    }
}
