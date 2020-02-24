using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupApp.Models;
using Xamarin.Forms;

namespace GroupApp
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            menuPage.listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageItem;
            if (item != null)
            {
                NavigationPage p=Detail as NavigationPage;
                if (p!=null && item.TargetType == p.RootPage.GetType())
                {
                    //mpiva: we already have a map in detail, we can reuse it.
                    MapsPage maps=p.RootPage as MapsPage;
                    if (maps!=null && item.AdditionalPush == Push.NewGroup)
                        Device.InvokeOnMainThreadAsync(async () => await maps.PushNewGroup());
                }
                else
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    MapsPage maps2=Detail as MapsPage;
                    if (maps2!=null && item.AdditionalPush == Push.NewGroup)
                    {
                        //mpiva: case maps is new
                        maps2.ShouldPushNewGroup = true;
                    }
                }

                menuPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}