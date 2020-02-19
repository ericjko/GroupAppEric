using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using GroupApp.Models;

namespace GroupApp.DB
{
    public class UserDatabase
    {
        SQLiteConnection conn;
        public UserDatabase(string database)
        {
            conn = new SQLiteConnection(database);
            conn.CreateTable<User>();
        }

        //function to register a new user to the account takes in the name and password the user enters then hashes the password
        //before creating a new user object with that name and password which is stored into the database.
        public void Register(string name, string pass, string email)
        {
            pass = Hash.hashPass(pass);
            var A = new User { Name = name, Password = pass, Email = email };
            conn.Insert(new User { Name = A.Name, Password = A.Password, Email = A.Email });
        }

        // takes in a name and searches for a user in the database with that name if it finds them, it returns that user
        // otherwise it returns null
        public User getUser(string name)
        {
            var user = from i in conn.Table<User>()
                       where i.Name == name
                       select i;
            return user.FirstOrDefault();
        }

        // takes in a name and searches for a user in the database with that name, if it finds them, it returns only the ID
        // of that user, else return null
        public int getUserID(string name)
        {
            var user = conn.Table<User>()
                .Where(i => i.Name == name)
                .FirstOrDefault();

            return user.Id;
        }

        public User getUserById(int id)
        {
            var user = from i in conn.Table<User>()
                       where i.Id == id
                       select i;
            return user.FirstOrDefault();
        }

    }
}
