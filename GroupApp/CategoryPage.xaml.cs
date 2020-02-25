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
            Categories cat = picker.SelectedItem as Categories;
            if (cat != null)
            { 
            //sets category id
            int catid = App.setCategoryID(cat.ID);
            await Navigation.PushAsync(new MapsPage());
            }
            else
            {
                await DisplayAlert("Error","Please choose a major", "Ok");
            }
        }


    }
}
