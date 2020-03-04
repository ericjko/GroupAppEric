using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GroupApp.Models
{
    public class CustomMap : Map
    {
        public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create("CustomPins", typeof(IEnumerable<CustomPin>), typeof(CustomMap),
            null, propertyChanged: OnItemsChanged);

        public IEnumerable<CustomPin> CustomPins
        {
            get { return (IEnumerable<CustomPin>)GetValue(CustomPinsProperty); }
            set { SetValue(CustomPinsProperty, value); }
        }

        static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var map = bindable as CustomMap;

            if (oldValue is INotifyCollectionChanged)
                (oldValue as INotifyCollectionChanged).CollectionChanged -= map.OnCollectionChanged;
            if (newValue is INotifyCollectionChanged)
                (newValue as INotifyCollectionChanged).CollectionChanged += map.OnCollectionChanged;

            map.OnCollectionChanged(map, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (newValue != null)
                map.OnCollectionChanged(map, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (IList)newValue));
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
                Pins.Clear();

            if (e.OldItems != null)
            {
                foreach (CustomPin pin in e.OldItems)
                {
                    Pins.Remove(pin);
                    pin.PropertyChanged -= OnPropertyChanged;
                }
            }

            if (e.NewItems != null)
            {
                foreach (CustomPin pin in e.NewItems)
                {
                    Pins.Add(pin);
                    pin.PropertyChanged += OnPropertyChanged;
                }
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // We should be able to just replace the changed pin, but rebuild is required to force map refresh
            Pins.Clear();
            foreach (var pin in CustomPins)
                Pins.Add(pin);
        }
    }
}
