using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GroupApp.Models
{
    public class CustomPin : Pin, INotifyPropertyChanged
    {
        private string _group = "";
        private string _name = "";
        private string _url = "";
        private ImageSource _imagedata;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Group
        {
            get => _group;
            //to edit
            set
            {
                if (!_group.Equals(value))
                {
                    _group = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_group)));
                }
            }
        }
        public string Name
        {
            get => _name;
            //to edit
            set
            {
                if (!_name.Equals(value))
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_name)));
                }
            }
        }

        public string Url
        {
            get => _url;
            //to edit
            set
            {
                if (!_url.Equals(value))
                {
                    _url = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_url)));
                }
            }

        }
        public ImageSource ImageData
        {
            get => _imagedata;
            //to edit
            set
            {
                if (!_url.Equals(value))
                {
                    _imagedata = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_imagedata)));
                }
            }

        }
    }
}
