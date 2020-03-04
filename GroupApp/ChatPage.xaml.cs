using System;
using System.Collections.Generic;
using GroupApp.Models;
using GroupApp.ViewModels;
using Xamarin.Forms;

namespace GroupApp
{
    public partial class ChatPage : ContentPage
    {

        public ChatPage()
        {
            this.BindingContext = new ChatViewModel();
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            nameEntry.Text = App.getUserName();
            groupEntry.Text = App.getUserGroup();
        }
    }
}
