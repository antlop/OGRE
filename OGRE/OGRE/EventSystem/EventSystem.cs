using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGRE.Events
{
    class EventSystem
    {
        private static readonly Lazy<EventSystem>
            lazy =
            new Lazy<EventSystem>
                (() => new EventSystem());

        public static EventSystem Instance { get { return lazy.Value; } }


        private Dictionary<string, List<IListener>> EventListeners;

        private EventSystem()
        {
            EventListeners = new Dictionary<string, List<IListener>>();
        }

        public void RegisterListenerForEvent(string eventName, IListener listener)
        {
            if( EventListeners.ContainsKey(eventName))
            {
                EventListeners[eventName].Add(listener);
            } else
            {
                List<IListener> list = new List<IListener>();
                list.Add(listener);
                EventListeners.Add(eventName, list);
            }
        }

        public bool TriggerEvent<T>(string eventName, T obj)
        {
            if (EventListeners.ContainsKey(eventName))
            {
                foreach(IListener listener in EventListeners[eventName])
                {
                    listener.HandleEvent(eventName, obj);
                }
                return true;
            }
            return false;
        }
    }
}
