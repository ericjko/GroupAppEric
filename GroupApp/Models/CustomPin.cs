using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GroupApp.Models
{
    public class CustomPin : Pin, INotifyPropertyChanged
    {
        

        private string _name = "";
        private string _url = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => _name;
            //to edit
            set
            {
                if (!_name.Equals(value))
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
                }
            }

        }

        public delegate void CustomClickHandler(object sender, PinClickedEventArgs args);

        public event CustomClickHandler InfoClick;

        public void DoInfoClickEvent()
        {
            Device.BeginInvokeOnMainThread(()=>
            {
                InfoClick?.Invoke(this, new PinClickedEventArgs());
            });
        }
    }
}
