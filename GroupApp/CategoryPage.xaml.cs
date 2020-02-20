using System;
using System.Collections.Generic;
using GroupApp.Models;
using GroupApp.ViewModels;
using Xamarin.Forms;

namespace GroupApp
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            BindingContext = new CategoryViewModel();
        }

        async void NextButtonClicked(object sender, EventArgs e)
        {
            //cat holds category properties
            var cat = picker.ItemsSource[picker.SelectedIndex];

            //gets category ID property, stores into catID
            System.Reflection.PropertyInfo pi = cat.GetType().GetProperty("ID");
            int catID = (int)(pi.GetValue(cat, null));

            //sets category id
            int catid = App.setCategoryID(catID);


            await Navigation.PushAsync(new MapsPage());
        }
        

    }
}
