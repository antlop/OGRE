using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OGREAPI.Controllers;

namespace OGRE
{
    [Serializable]
    public class Event
    {
        public Dictionary<string, int> Submissions;
        public Dictionary<string, Item> WinnableItems;

        public Event()
        {
            Submissions = new Dictionary<string, int>();
            WinnableItems = new Dictionary<string, Item>();
        }
    }
}
