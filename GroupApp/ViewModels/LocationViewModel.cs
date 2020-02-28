using System;
using System.ComponentModel;
using Xamarin.Forms.Maps;

namespace GroupApp.ViewModels
{
    public class Locations : INotifyPropertyChanged
    {
        Position _position;
        private string _address = "";
        private string _description = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Address
        {
            get => _address;
            //to edit
            set
            {
                if (!_address.Equals(value))
                {
                    _address = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }
        public string Description
        {
            get => _description;
            //to edit
            set
            {
                if (!_description.Equals(value))
                {
                    _description = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                }
            }

        }
        public int AutomationID { get; }

        public Position Position
        {
            get => _position;
            set
            {
                if (!_position.Equals(value))
                {
                    _position = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
                }
            }
        }
        public Locations(int id, string address, string description, Position position)
        {
            AutomationID = id;
            Address = address;
            Description = description;
            Position = position;
        }

    }
}
