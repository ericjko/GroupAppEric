using System;
using System.Collections.Generic;
using GroupApp.Models;
using GroupApp.ViewModels;
using Xamarin.Forms;

namespace GroupApp
{
    public partial class CategoryPage : TabbedPage
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
            Categories cat2 = picker2.SelectedItem as Categories;
            if (cat != null || cat2 != null)
            { 
            //sets category id
                if (cat2 == null)
                { 
                    int catid = App.setCategoryID(cat.ID);
                }
                else if (cat == null)
                {
                    int catid = App.setCategoryID(cat2.ID);
                }
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error","Please choose a major", "Ok");
            }
        }


    }
}
