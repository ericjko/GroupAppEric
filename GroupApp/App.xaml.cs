using System;
using System.IO;
using GroupApp;
using GroupApp.Data;
using GroupApp.DB;
using GroupApp.LoginPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupApp
{
    public partial class App : Application
    {
        public static string usercheck;
        static int userId;

        string Database => AccessFile.FilePath("db");
        public static UserDatabase UserDB { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MapsPage());
            //MainPage = new NavigationPage(new Login());

            UserDB = new UserDatabase(Database);
        }
        public string getusercheck()
        {
            return usercheck;
        }
        public void setusercheck(string name)
        {
            usercheck = name;
        }

        //set user id and get user id allows to access user id anywhere in application
        public static int getUserID()
        {
            return userId;
        }
        public static int setUserID(int id)
        {
            userId = id;
            return userId;
        }
        static PinDatabase pindatabase;

        public static PinDatabase PinDatabase
        {
            get
            {
                if (pindatabase == null)
                {
                    pindatabase = new PinDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pin15.db3"));
                }
                return pindatabase;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
