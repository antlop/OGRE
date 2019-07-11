using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    [Serializable]
    public class Event
    {
        public Dictionary<string, int> Submissions;
        public Dictionary<string, Item> WinnableItems;

        public Event()
        {
            Submissions = new Dictionary<string, int>();

            Submissions.Add("Anton", 1);

            WinnableItems = new Dictionary<string, Item>();
        }
    }
}
