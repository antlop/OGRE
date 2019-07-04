using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    public class EventDatabase
    {
        private static readonly Lazy<EventDatabase> lazy = new Lazy<EventDatabase>(() => new EventDatabase());
        public static EventDatabase Instance { get { return lazy.Value; } }
        
        private EventDatabase()
        {
            Submissions = new List<User>();

            User user = new User("Anton", "Lopez", 0);
            Submissions.Add(user);
        }

        public List<User> Submissions;
    }
}
