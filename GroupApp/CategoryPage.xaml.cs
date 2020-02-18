using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GroupApp
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        async void NextButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapsPage());


        }

    }
}
