using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OGREAPI.Controllers
{
    public sealed class BankDatabase
    {
        private static readonly Lazy<BankDatabase> lazy = new Lazy<BankDatabase>(() => new BankDatabase());
        public static BankDatabase Instance { get { return lazy.Value; } }
        private BankDatabase()
        {
            /*
            m_Bank = new Bank();

            
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
        public string BankKey;

        public void AddItemToBankTab(Item item, int TabIndex)
        {
            if (TabIndex >= m_Bank.BankTabs.Count)
            {
                CreateAdditionalTab("");
                m_Bank.BankTabs[m_Bank.BankTabs.Count - 1].AddItem(item);
            } else
            {
                if (m_Bank.BankTabs[TabIndex].ItemsDictionary.ContainsKey(item.ItemID))
                {
                    m_Bank.BankTabs[TabIndex].ItemsDictionary[item.ItemID].StackSize += item.StackSize;
                } else
                {
                    m_Bank.BankTabs[TabIndex].AddItem(item);
                }
            }
        }

        void CreateAdditionalTabs(int TargetIndex)
        {
            while (TargetIndex >= m_Bank.BankTabs.Count)
            {
                Grouping grouping = new Grouping();
                m_Bank.BankTabs.Add(grouping);
            }
        }

        public void CreateAdditionalTab(string name) {
            Grouping grouping = new Grouping();
            grouping.Name = name;
            m_Bank.BankTabs.Add(grouping);
        }

        public void SetTabName(int index, string name) {
            if( m_Bank.BankTabs.Count < index) {
                m_Bank.BankTabs[index].Name = name;
            }
        }

        public bool RemoveItem(int itemID, int tabIndex, int count)
        {
            if( tabIndex < m_Bank.BankTabs.Count )
            {
                return m_Bank.BankTabs[tabIndex].RemoveItem(itemID, count);
            }

            return true;
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
            string str = "{ \"BankTabs\": [";

            int count = 0;
            foreach (Grouping tab in m_Bank.BankTabs)
            {
                if (Convert.ToInt32(tab.ViewPermission) <= rank)
                {
                    str += JsonConvert.SerializeObject(tab);
                    if (count + 1 < m_Bank.BankTabs.Count)
                    {
                        str += ", ";
                    }
                }
                count++;
            }
            return str + "], \"VersionNumber\":" + GetBankVersionNumber() + ", \"WrapVersionNumber\":" + m_Bank.WrapVersionNumber.ToString() + "}";
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
