using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGRE.Events
{
    interface IListener
    {
        void HandleEvent<T>(string eventName, T obj);
    }
}
