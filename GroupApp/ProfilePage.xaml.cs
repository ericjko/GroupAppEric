using System;
using System.Collections.Generic;
using System.IO;
using GroupApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using GroupApp.Models;
using GroupApp.LoginPage;
using System.Threading.Tasks;

namespace GroupApp
{
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage()
        {

            BindingContext = new ProfilePageViewModel();
            InitializeComponent();

            int currentUserId = App.getUserID();

            User currentUser = App.UserDB.getUserById(currentUserId);

            UserNameLabel.Text = currentUser.Name;
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

            (sender as Button).IsEnabled = true;
        }
    }
}
