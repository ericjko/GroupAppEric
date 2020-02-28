using System;
using System.Collections.Generic;
using GroupApp.Models;


namespace GroupApp.ViewModels
{
    public class CategoryViewModel
    {
        public static int PickerSelectedIndex = 0;
        public IList<Categories> _Categories { get { return CategoryData._Categories; } }
		
	}
}
