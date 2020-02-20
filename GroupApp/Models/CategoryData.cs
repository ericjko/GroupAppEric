using System;
using System.Collections.Generic;

namespace GroupApp.Models
{
    public class CategoryData
    {
        public static IList<Categories> _Categories { get; private set; }

        static CategoryData()
        {
            _Categories = new List<Categories>();

            _Categories.Add(new Categories
            {
                ID = 1,
                Category = "Math",
            });
            _Categories.Add(new Categories
            {
                ID = 2,
                Category = "Science",
            });
            _Categories.Add(new Categories
            {
                ID = 3,
                Category = "Biology",
            });
            _Categories.Add(new Categories
            {
                ID = 4,
                Category = "Physics",
            });
        }
    }
}
