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
            if (picker.SelectedItem != null)
            {
                Categories cat = picker.SelectedItem as Categories;
                if (cat != null)
                {
                    MapsPage page = new MapsPage();
                    page.FilterCategory = cat;
                    await Navigation.PushAsync(page);
                }
            }
        }
        

    }
}
