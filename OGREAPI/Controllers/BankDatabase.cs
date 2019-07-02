using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    [Serializable]
    public sealed class BankDatabase
    {
        private static readonly Lazy<BankDatabase> lazy = new Lazy<BankDatabase>(() => new BankDatabase());
        public static BankDatabase Instance { get { return lazy.Value; } }
        private BankDatabase()
        {
            BankTabs = new List<Grouping>();

            Item itemA = new Item(24, "Thunderfury");
            AddItemToBankTab(itemA, 0);

            for (int i = 0; i < 20; i++)
            {
                Item itemB = new Item(103, "Wool Cloth");
                AddItemToBankTab(itemB, 0);
            }

            Item itemC = new Item(3355, "Shadowcap");
            AddItemToBankTab(itemC, 0);

            Item itemD = new Item(5757, "Ashbringer");
            AddItemToBankTab(itemD, 4);
        }


        List<Grouping> BankTabs;
        public int VersionNumber;
        public int WrapVersionNumber = 1024;

        public void AddItemToBankTab(Item item, int TabIndex)
        {
            CreateAdditionalTabs(TabIndex);
            BankTabs[TabIndex].AddItem(item);
        }

        void CreateAdditionalTabs(int TargetIndex)
        {
            do
            {
                Grouping grouping = new Grouping();
                BankTabs.Add(grouping);
            } while (TargetIndex >= BankTabs.Count);
        }

        public void RemoveItem(int itemID, int tabIndex, int count)
        {
            if( tabIndex < BankTabs.Count )
            {
                BankTabs[tabIndex].RemoveItem(itemID, count);
            }
        }

        public Item GetItemWithID(int itemID)
        {
            foreach(Grouping tab in BankTabs)
            {
                if(tab.ItemsDictionary != null && tab.ItemsDictionary.ContainsKey(itemID))
                {
                    return tab.ItemsDictionary[itemID];
                }
            }
            return null;
        }

        public override string ToString()
        {
            string str = "{ \"Bank\": {\"Version\": \"" + GetBankVersionNumber() + "\",\"Tabs\": [";

            int count = 0;
            foreach (Grouping tab in BankTabs)
            {
                if (tab.ItemsDictionary != null)
                {
                    str += tab.ToString();
                    if (count + 1 < BankTabs.Count)
                    {
                        str += ", ";
                    }
                }
                count++;
            }
            return str + "] } }";
        }

        public void IncreaseVersionNumber()
        {
            VersionNumber++;
            if( VersionNumber >= WrapVersionNumber)
            {
                VersionNumber = 0;
            }
        }

        public int GetBankVersionNumber()
        {
            return VersionNumber;
        }
    }
}
