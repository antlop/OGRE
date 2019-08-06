using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using OGRE.Events;
using OGREAPI.Controllers;
using Newtonsoft.Json;
using System.IO;
using System.Timers;

// retreave item info
// https://www.wowhead.com/item=00018604&xml

// retreave item icon
// https://wow.zamimg.com/images/wow/icons/large/inv_misc_gem_amethyst_03.jpg

namespace OGRE
{
    public partial class MainPage : Form, IListener
    {
        public User user;
        public Bank m_Bank;
        public Event m_Event;
        private Timer m_PendingPollTimer;

        public MainPage()
        {
            InitializeComponent();
            user = User.Instance;

            LoginPage page = new LoginPage();
            page.Show(this);

            EventSystem.Instance.RegisterListenerForEvent("LoginEvent", this);
            EventSystem.Instance.RegisterListenerForEvent("BankItemSelected", this);
            EventSystem.Instance.RegisterListenerForEvent("RefreshBank", this);
            EventSystem.Instance.RegisterListenerForEvent("DeleteFromBank", this);

            //m_Explorer = new WowExplorer(WowDotNetAPI.Region.US, Locale.en_US, "732aa68878154a04964e12aed8fddfad");


            //Assume App is going to be used by non-Leader
            ManageBankTabButton.Visible = false;
            AddBankTabButton.Visible = false;
            NewTabNameTextBox.Visible = false;
            AddonPathTextBox.Visible = false;
            FolderDialButton.Visible = false;

            AddonPathTextBox.Text = "C:\\Program Files (x86)\\World of Warcraft\\_classic_\\Interface\\AddOns\\OGRE";

        }

        async public void LoadDataForBankList()
        {

            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Bank//" + Convert.ToInt32(User.Instance.Rank);
            string retsz = "";
            try
            {
                retsz = await client.GetStringAsync(path);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var bank = JsonConvert.DeserializeObject<Bank>(retsz);
            m_Bank = bank;

            int count = m_Bank.BankTabs.Count;
            TabComboBox.Items.Clear();
            for (int index = 0; index < count; index++)
            {
                string name = m_Bank.BankTabs[index].Name;
                if( name == "Tab") { name += " " + index.ToString(); }
                TabComboBox.Items.Add(name);
            }
            TabComboBox.SelectedIndex = 0;

            LoadDataForItem(m_Bank.BankTabs[TabComboBox.SelectedIndex].ItemsDictionary.First().Value.ItemID);
        }

        async public void LoadDataForItem(int id)
        {
            HttpClient client = new HttpClient();
            string path = string.Format("https://www.wowhead.com/item={0}&xml", id);
            string retsz = "";
            try
            {
                retsz = await client.GetStringAsync(path);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var xDoc = XDocument.Parse(retsz);
            var icon = xDoc.Descendants("icon").Single();
            SelectedItemIcon.LoadAsync(string.Format("https://wow.zamimg.com/images/wow/icons/large/{0}.jpg", icon.Value));

            Console.WriteLine(retsz);
        }

        public void HandleEvent<T>(string eventName, T obj)
        {
            if (eventName == "LoginEvent")
            {
                MainTabControl.Visible = true;
                LoadDataForBankList();

                if (User.Instance.Rank == MemberRanks.GUILD_MASTER)
                {
                    ManageBankTabButton.Visible = true;
                    AddBankTabButton.Visible = true;
                    NewTabNameTextBox.Visible = true;
                    AddonPathTextBox.Visible = true;
                    FolderDialButton.Visible = true;

        		    m_PendingPollTimer = new Timer(300000); // 1 sec = 1000, 60 sec = 60000
		            t.AutoReset = true;
		            t.Elapsed += new System.Timers.ElapsedEventHandler(LoadDataForBankTable);
		            t.Start();
                }
            }
            if( eventName == "BankItemSelected")
            {
                LoadDataForItem((obj as Item).ItemID);
            }
            if( eventName == "DeleteFromBank")
            {
                DeleteItemFromBank(TabComboBox.SelectedIndex, (obj as Item).ItemID);
            }
        }

        private void TabComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForBankTable();
        }

        private void LoadDataForBankTable()
        {
            int tabIndex = TabComboBox.SelectedIndex;
            tableLayoutPanel2.Controls.Clear();

            List<Item> ItemList = RetreaveXMLPendingSubmissions();

            if (tabIndex < m_Bank.BankTabs.Count)
            {
                if (m_Bank.BankTabs[tabIndex].ItemsDictionary == null) { return; }

                int count = m_Bank.BankTabs[tabIndex].ItemsDictionary.Count;

                foreach (Item item in m_Bank.BankTabs[tabIndex].ItemsDictionary.Values)
                {
                    ItemList.Add(item);
                }
            }

            int col = 0;
            int row = 0;
            foreach (Item item in ItemList)
            {
                RowStyle style = new RowStyle(SizeType.Absolute);
                style.Height = 80;
                tableLayoutPanel2.RowStyles.Add(style);

                CellForItemList cell = new CellForItemList(item);

                tableLayoutPanel2.Controls.Add(cell, col, row);

                tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;

                col++;
                if (col == tableLayoutPanel2.ColumnCount)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private List<Item> RetreaveXMLPendingSubmissions()
        {
            List<Item> retList = new List<Item>();

            if( User.Instance.Rank == MemberRanks.MEMBER) [
                return retList;
            ]

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(AddonPathTextBox.Text + "\\ParsedSubmissionsToGuildBank.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Submission");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                string submitter = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                int itemID = Convert.ToInt32(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                int stackSize = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());
                string itemName = xmlnode[i].ChildNodes.Item(4).InnerText.Trim();

                Item item = new Item(itemID, itemName);
                item.StackSize = stackSize;
                item.Sender = submitter;
                item.Pending = true;

                retList.Add(item);
            }
            return retList;
            /**/
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForEvent();
            LoadUserForEvent();
        }

        async public void LoadDataForEvent()
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Event";
            string retsz = "";
            try
            {
                retsz = await client.GetStringAsync(path);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var EventItems = JsonConvert.DeserializeObject<Dictionary<string, Item>>(retsz);
            if (m_Event == null)
            {
                m_Event = new Event();
            }
            m_Event.WinnableItems = EventItems;


            EventItemsList.Controls.Clear();

            int row = 0;
            foreach (Item item in m_Event.WinnableItems.Values)
            {
                RowStyle style = new RowStyle(SizeType.Absolute);
                style.Height = 80;
                EventItemsList.RowStyles.Add(style);

                Label label = new Label();
                label.Text = item.Name;
                EventItemsList.Controls.Add(label, 0, row);

                row++;
            }
        }

        async public void LoadUserForEvent()
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Event//Entries";
            string retsz = "";
            try
            {
                retsz = await client.GetStringAsync(path);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Entries = JsonConvert.DeserializeObject<Dictionary<string, int>>(retsz);
            if( m_Event == null )
            {
                m_Event = new Event();
            }
            m_Event.Submissions = Entries;

            int entries = 0;
            if (m_Event.Submissions.ContainsKey(User.Instance.Username)) {
                entries = m_Event.Submissions[User.Instance.Username];
            }

            CurrentEventEntries.Text = "Number of Tickets in Current Event: " + entries.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SubmitToEvent(1);
        }

        async public void SubmitToEvent(int tokenCount)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += string.Format("//Event//AddSubmission//{0}//{1}", User.Instance.Username, tokenCount);
            string retsz = "";
            try
            {
                retsz = await client.GetStringAsync(path);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if( retsz == "Success")
            {
                // Reset local event token counter
                LoadUserForEvent();
            } else
            {
                MessageBox.Show(retsz, "Oops..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SubmitToEvent(Convert.ToInt32(eventTokenSubmissionCount.Value));
        }

        private void ManageBankTabButton_Click(object sender, EventArgs e)
        {
        }

        private void AddBankTabButton_Click(object sender, EventArgs e)
        {

        }

        async private void AddBankTab(string name)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Bank//AddTab//" + name;
            HttpResponseMessage retsz;
            try
            {
                retsz = await client.PostAsync(path,null);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadDataForBankList();
        }

        async private void DeleteItemFromBank(int tab, int id)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Bank//" + string.Format("{0}//{1}//{2}", tab, id, 99999);
            HttpResponseMessage retsz;
            try
            {
                retsz = await client.DeleteAsync(path);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FolderDialButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddonPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
            //AddonPathTextBox.Text = "C:\\Program Files (x86)\\World of Warcraft\\_classic_\\Interface\\AddOns\\OGRE"
        }
    }
}
