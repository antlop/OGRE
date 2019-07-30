using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    public sealed class BankDatabase
    {
        private static readonly Lazy<BankDatabase> lazy = new Lazy<BankDatabase>(() => new BankDatabase());
        public static BankDatabase Instance { get { return lazy.Value; } }
        private BankDatabase()
        {
            m_Bank = new Bank();

            /*
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
            */
        }

        /*
        public List<Grouping> BankTabs;
        public int VersionNumber;
        public int WrapVersionNumber = 1024;
        */

        public Bank m_Bank;

        public void AddItemToBankTab(Item item, int TabIndex)
        {
            CreateAdditionalTabs(TabIndex);
            m_Bank.BankTabs[TabIndex].AddItem(item);
        }

        void CreateAdditionalTabs(int TargetIndex)
        {
            while (TargetIndex >= m_Bank.BankTabs.Count)
            {
                Grouping grouping = new Grouping();
                m_Bank.BankTabs.Add(grouping);
            } 
        }

        public void RemoveItem(int itemID, int tabIndex, int count)
        {
            if( tabIndex < m_Bank.BankTabs.Count )
            {
                m_Bank.BankTabs[tabIndex].RemoveItem(itemID, count);
            }
        }

        public Item GetItemWithID(int itemID)
        {
            foreach(Grouping tab in m_Bank.BankTabs)
            {
                if(tab.ItemsDictionary != null && tab.ItemsDictionary.ContainsKey(itemID))
                {
                    return tab.ItemsDictionary[itemID];
                }
            }
            return null;
        }
      
        public string GetBankAsJSON(int rank) {
          
            string str = "{ \"Bank\": {\"Version\": \"" + GetBankVersionNumber() + "\",\"Tabs\": [";

            int count = 0;
            foreach (Grouping tab in m_Bank.BankTabs)
            {
                if (tab.ItemsDictionary != null && Convert.ToInt32(tab.ViewPermission) < rank)
                {
                    str += tab.ToString();
                    if (count + 1 < m_Bank.BankTabs.Count)
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
            m_Bank.VersionNumber++;
            if(m_Bank.VersionNumber >= m_Bank.WrapVersionNumber)
            {
                m_Bank.VersionNumber = 0;
            }
        }

        public int GetBankVersionNumber()
        {
            return m_Bank.VersionNumber;
        }
    }
}
