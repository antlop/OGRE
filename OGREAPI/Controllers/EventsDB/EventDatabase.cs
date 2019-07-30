using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OGREAPI.Controllers
{
    public class EventDatabase
    {
        private static readonly Lazy<EventDatabase> lazy = new Lazy<EventDatabase>(() => new EventDatabase());
        public static EventDatabase Instance { get { return lazy.Value; } }

        private EventDatabase()
        {
            m_Event = new Event();
        }

        public Event m_Event;

        public void AddSubmission(string name)
        {
            if( m_Event.Submissions.ContainsKey(name))
            {
                m_Event.Submissions[name] += 1;
            }
            else
            {
                m_Event.Submissions.Add(name, 1);
            }
        }

        public void AddItem(Item item)
        {
            if (m_Event.WinnableItems.ContainsKey(item.Name))
            {
                m_Event.WinnableItems[item.Name].StackSize += 1;
            }
            else
            {
                m_Event.WinnableItems.Add(item.Name, item);
            }
        }

        public void ResetEvent()
        {
            ResetSubmission();
            ResetItems();
        }

        public void ResetSubmission()
        {
            m_Event.Submissions.Clear();
        }

        public void ResetItems()
        {
            m_Event.WinnableItems.Clear();
        }

        public string GetJSONWinnableItems()
        {
            string json = JsonConvert.SerializeObject(m_Event.WinnableItems);
            return json;
        }

        public string GetJSONEntrys()
        {
            string json = JsonConvert.SerializeObject(m_Event.Submissions);
            return json;
        }

    }
}
