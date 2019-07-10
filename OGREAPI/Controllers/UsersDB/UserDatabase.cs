using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    public class UserDatabase
    {
        private static readonly Lazy<UserDatabase> lazy = new Lazy<UserDatabase>(() => new UserDatabase());
        public static UserDatabase Instance { get { return lazy.Value; } }
        
        private UserDatabase()
        {
            UsersDB = new Dictionary<string, User>();

		Random rand = new Random();
            User user = new User("Anton+" + rand.Next(1,99999).ToString(), "Lopez", 0);
            UsersDB.Add("Anton", user);
        }

        public Dictionary<string, User> UsersDB;

        public bool DatabaseContainsKey(string key)
        {
            bool containsKey = false;
            lock(UsersDB)
            {
                if( UsersDB.ContainsKey(key) )
                {
                    containsKey = true;
                }
            }
            return containsKey;
        }
    }
}
