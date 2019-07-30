using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    [Serializable]
    public class Item
    {
        public int ItemID;
        public string Name;
        public int StackSize = 1;
        public string Sender;
        public bool Pending = false;

        public Item(Item item, int stackSize)
        {
            ItemID = item.ItemID;
            Name = item.Name;
            StackSize = stackSize;
        }

        public Item() { }

        public Item(int id, string name)
        {
            ItemID = id;
            Name = name;
        }

        public string GetReportable()
        {
            string returnsz = Name;
            if( StackSize > 1)
            {
                returnsz += "=" + StackSize;
            }
            return returnsz;
        }

        public override string ToString()
        {
            string str = "\"Name\": \"" + Name + "\",\"Count\": " + StackSize.ToString() + ",\"ID\": " + ItemID.ToString();
            return str;
        }
    }
}
