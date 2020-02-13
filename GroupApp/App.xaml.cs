using System;
using System.IO;
using GroupApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MapsPage());
        }
        static PinDatabase pindatabase;

        public static PinDatabase PinDatabase
        {
            get
            {
                if (pindatabase == null)
                {
                    pindatabase = new PinDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pin5.db3"));
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
