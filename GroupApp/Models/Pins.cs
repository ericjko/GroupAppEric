using System;
using SQLite;
namespace GroupApp.Models
{
    public class Pins
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }

    }
}
