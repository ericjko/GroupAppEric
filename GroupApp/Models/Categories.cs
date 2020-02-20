using System;
using SQLite;

using Xamarin.Forms;

namespace GroupApp.Models
{
    public class Categories : ContentPage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Category { get; set; }
    }
}

