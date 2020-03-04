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
        static int catId;
        static string userEmail;
        static string userGroup;
        static string userName;


        string Database => AccessFile.FilePath("db8");
        public static UserDatabase UserDB { get; private set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new CategoryPage());
            MainPage = new NavigationPage(new Login());


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
        //set category id and get category id allows to access anywhere in application
        public static int getCategoryID()
        {
            return catId;
        }
        public static int setCategoryID(int id)
        {
            catId = id;
            return catId;
        }

        public static string getUserEmail()
        {
            return userEmail;
        }

        public static string setUserEmail(string email)
        {
            userEmail = email;
            return email;
        }
        public static string getUserGroup()
        {
            return userGroup;
        }

        public static string setUserGroup(string group)
        {
            userGroup = group;
            return group;
        }
        public static string getUserName()
        {
            return userName;
        }

        public static string setUserName(string name)
        {
            userName = name;
            return name;
        }


        static PinDatabase pindatabase;

        public static PinDatabase PinDatabase
        {
            get
            {
                if (pindatabase == null)
                {
                    pindatabase = new PinDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pin33.db3"));
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
