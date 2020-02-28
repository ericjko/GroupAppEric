using System;
using System.Collections.Generic;

namespace GroupApp.Models
{
    public class ClubData
    {
        public static IList<Categories> _Clubs { get; private set; }

        static ClubData()
        {
            _Clubs = new List<Categories>();

            _Clubs.Add(new Categories
            {
                ID = 5,
                Category = "Basketball",
            });

            _Clubs.Add(new Categories
            {
                ID = 6,
                Category = "Wrestling",
            });
        }
    }
}
