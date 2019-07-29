using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    [Serializable]
    public enum MemberRanks
    {
        MEMBER,
        GUILD_LEADER,
        GUILD_MASTER
    }
    public class Grouping
    {
        public Dictionary<int, Item> ItemsDictionary;
        public MemberRanks ViewPermission = MemberRanks.MEMBER;
        public MemberRanks AddPermission = MemberRanks.GUILD_LEADER;
        public MemberRanks RemovePermission = MemberRanks.GUILD_MASTER;
        public string Name = "Tab";

        public void AddItem(Item item)
        {
            if( ItemsDictionary == null )
            {
                ItemsDictionary = new Dictionary<int, Item>();
            }

            if( ItemsDictionary.ContainsKey(item.ItemID))
            {
                ItemsDictionary[item.ItemID].StackSize++;
            } else
            {
                ItemsDictionary.Add(item.ItemID, item);
            }
        }

        public void RemoveItem(int itemID, int count)
        {
            if (ItemsDictionary != null && ItemsDictionary.ContainsKey(itemID))
            {
                if( ItemsDictionary[itemID].StackSize > count )
                {
                    ItemsDictionary[itemID].StackSize -= count;
                } else
                {
                    ItemsDictionary.Remove(itemID);
                }
            }
        }

        public bool DoesHaveViewPermission(MemberRanks rank)
        {
            if( rank >= ViewPermission )
            {
                return true;
            }
            return false;
        }

        public bool DoesHaveAddPermission(MemberRanks rank)
        {
            if (rank >= AddPermission)
            {
                return true;
            }
            return false;
        }
        public bool DoesHaveRemovePermission(MemberRanks rank)
        {
            if (rank >= RemovePermission)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string str = "{\"ViewPerm\":\"" + ViewPermission.ToString() + "\", \"AddPerm\":\"" + AddPermission.ToString() + "\", \"RemovePerm\":\"" + RemovePermission.ToString() + "\", \"Items\": [";
            int count = 0;
            foreach (Item item in ItemsDictionary.Values)
            {
                str += "{" + item.ToString() + "}";
                if (count + 1 < ItemsDictionary.Values.Count)
                {
                    str += ", ";
                }
                count++;
            }
            str += "] }";
            return str;
        }
    }
}
