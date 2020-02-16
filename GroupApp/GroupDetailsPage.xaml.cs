using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace GroupApp
{
    public partial class GroupDetailsPage : ContentPage
    {
        public GroupDetailsPage()
        {
            InitializeComponent();

    }

        async void OnJoinButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://mail.google.com/mail/mu/mp/755/#co");
        }
    }


}

