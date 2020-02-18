using System;
using System.ComponentModel;
using Xamarin.Forms.Maps;

namespace GroupApp.ViewModels
{
    public class Location: INotifyPropertyChanged
    {
        Position _position;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Address { get; }
        public string Description { get; }
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
        public Location(int id, string address, string description, Position position)
        {
            AutomationID = id;
            Address = address;
            Description = description;
            Position = position;
        }

    }
}
