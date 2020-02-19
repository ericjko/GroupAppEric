using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupApp.LoginPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogBtn(object sender, EventArgs e)
        {
            // checks if user exusts in database
            if (App.UserDB.getUser(UsernameField.Text) == null) 
            {
                LogError.Text = "invalid details";
            }
            else
            {
                // checks if anything is entered inside of the text fields
                if (string.IsNullOrEmpty(PasswordField.Text) || string.IsNullOrEmpty(UsernameField.Text))
                {
                    LogError.Text = "invalid details";
                }
                else
                {
                    // checks if password is correct and logs user into next page
                    if (Hash.rehashPass(PasswordField.Text, UsernameField.Text))
                    {
                        App.usercheck = UsernameField.Text;

                        //get login user information
                        var user = App.UserDB.getUser(UsernameField.Text);

                        //sets userEmail
                        string useremail = App.setUserEmail(user.Email);

                        //sets userid
                        int userid = App.setUserID(user.Id);
                        App.Current.MainPage = new NavigationPage(new MapsPage());
                    }
                    else
                    {
                        LogError.Text = "invalid details";
                    }
                }
            }
        }
        // switches to register page
        private void RegBtn(object sender, EventArgs e)
        {
            UsernameField.Text = "";
            PasswordField.Text = "";
            LoginPage.IsVisible = false;
            RegPage.IsVisible = true;
        }

        // navigates to login page
        private void HveBtn(object sender, EventArgs e)
        {
            UsernameField2.Text = "";
            PasswordField2.Text = "";
            PasswordField3.Text = "";
            EmailField.Text = "";
            LoginPage.IsVisible = true;
            RegPage.IsVisible = false;
        }

        private void Regacc(object sender, EventArgs e)
        {
            // checks if user entered anything
            if (string.IsNullOrEmpty(PasswordField2.Text) || string.IsNullOrEmpty(PasswordField3.Text) || string.IsNullOrEmpty(UsernameField2.Text))
            {
                Error.Text = "invalid details";
            }

            else
            {
                // checks both password and reentered password are correct
                if (PasswordField2.Text == PasswordField3.Text)
                {
                    // makes sure that the password has at least 4 characters, has capital letter & number
                    if (PasswordField2.Text.Length >= 4 && PasswordField2.Text.Any(char.IsUpper) && PasswordField2.Text.Any(char.IsLower) && PasswordField2.Text.Any(char.IsDigit))
                    {
                        // calls register function and adds a new user to the database
                        App.UserDB.Register(UsernameField2.Text, PasswordField2.Text, EmailField.Text);

                        //changes back to login page
                        LoginPage.IsVisible = true;
                        RegPage.IsVisible = false;
                        UsernameField2.Text = "";
                        PasswordField2.Text = "";
                        PasswordField3.Text = "";
                    }

                    else
                    {
                        Error.Text = "password must contain atleast 4 letters, a number and a lower and upper case letter";
                    }
                }

                else
                {
                    Error.Text = "invalid details";
                }
            }
        }
    }
}
