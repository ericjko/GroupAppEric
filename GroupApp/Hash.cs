using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace GroupApp
{
    public static class Hash
    {
        public static string hashPass(string pass)
        {
            // creates empty 24 size byte 
            var salt = new byte[24];

            // sets the number of iterations that will occur when password is hashed
            int iterations = 1000;

            // creates an empty byte to store the hash
            byte[] hash;

            // randomly stores into the salt variable
            new RNGCryptoServiceProvider().GetBytes(salt);

            // produces a hash using the password and the randomly generated salt and the iterations
            var result = new Rfc2898DeriveBytes(pass, salt, iterations);

            // stores the result into the hash variable
            hash = result.GetBytes(24);

            // combines the hash the salt and the iterations and splits them up with |
            return Convert.ToBase64String(salt) + "|" + iterations + "|" + Convert.ToBase64String(hash);
        }

        public static bool rehashPass(string pass, string username)
        {
            // gets user trying to login
            var A = App.UserDB.getUser(username);

            // gets that users stored password and splits it from the | in order to separate the hash iterations and the salt
            var CombinedString = A.Password.Split('|');

            // gets the same salt used to create the password when they registered
            var salt = Convert.FromBase64String(CombinedString[0]);

            // gets iterations
            var iterations = Int32.Parse(CombinedString[1]);

            // gets the hash
            var hash = CombinedString[2];

            // recalculates the hash using the password the user entered
            var result = new Rfc2898DeriveBytes(pass, salt, iterations);

            // stores the hash
            var newhash = result.GetBytes(24);

            // checks if the hash created with the password they entered is the same as the hash stored in database for specific user
            if (hash == Convert.ToBase64String(newhash))
            {
                return true;
            }

            return false;
        }
    }

}
