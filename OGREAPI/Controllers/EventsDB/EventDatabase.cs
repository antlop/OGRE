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
            Submissions = new Dictionary<string, int>();

            Submissions.Add("Anton", 1);

            WinnableItems = new Dictionary<string, Item>();
        }

        public Dictionary<string, int> Submissions;
        public Dictionary<string, Item> WinnableItems;

        public void AddSubmission(string name)
        {
            if( Submissions.ContainsKey(name))
            {
                Submissions[name] += 1;
            }
            else
            {
                Submissions.Add(name, 1);
            }
        }

        public void AddItem(Item item)
        {
            WinnableItems.Add(item.Name, item);
        }

        public void ResetEvent()
        {
            ResetSubmission();
            ResetItems();
        }

        public void ResetSubmission()
        {
            Submissions.Clear();
        }

        public void ResetItems()
        {
            WinnableItems.Clear();
        }
    }
} 
