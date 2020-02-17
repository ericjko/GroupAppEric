using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace GroupApp
{
    class AccessFile
    {
        public static string FilePath(string file)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, file);
        }
    }
}