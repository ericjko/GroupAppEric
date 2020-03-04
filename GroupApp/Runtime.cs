using System;
using GroupApp.ViewModels;
using GroupApp.Models;

namespace GroupApp
{
    public class Runtime
    {
        public static PinItemsSourcePageViewModel Locations { get; } = new PinItemsSourcePageViewModel();
        public static ChatViewModel Chat { get; } = new ChatViewModel();
        //public static CustomPin customPin { get; } = new CustomPin();
        //public static CustomMap cMap { get; } = new CustomMap();
    }
}
 