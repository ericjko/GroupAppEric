using System;
using SQLite;
namespace GroupApp.Models
{
    public class Pins
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int userID { get; set; }
        public int categoryID { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
