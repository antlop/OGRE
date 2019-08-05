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
        public System.Timers.Timer m_PollPendingTimer;
        public int m_SelectedBankTab = 0;
        public List<Item> DisplayedBankItems;
        XmlDocument m_PendingXMLDoc;

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
            EventSystem.Instance.RegisterListenerForEvent("ApprovePending", this);
            EventSystem.Instance.RegisterListenerForEvent("RefreshBankList", this);

            //m_Explorer = new WowExplorer(WowDotNetAPI.Region.US, Locale.en_US, "732aa68878154a04964e12aed8fddfad");


            //Assume App is going to be used by non-Leader
            ManageBankTabButton.Visible = false;
            AddBankTabButton.Visible = false;
            NewTabNameTextBox.Visible = false;
            AddonPathTextBox.Visible = false;
            FolderDialButton.Visible = false;
            BankItemManage.Visible = false;
            ManagementToolsBox.Visible = false;

            AddonPathTextBox.Text = "C:\\Program Files (x86)\\World of Warcraft\\_classic_\\Interface\\AddOns\\OGRE";
        }

        async public void LoadDataForBankList(bool UpdateTable = false)
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
            TabComboBox.Invoke(new MethodInvoker(delegate {
                TabComboBox.Controls.Clear();
            }));
            for (int index = 0; index < count; index++)
            {
                string name = m_Bank.BankTabs[index].Name;
                if( name == "Tab") { name += " " + index.ToString(); }

                TabComboBox.Invoke(new MethodInvoker(delegate {
                    TabComboBox.Items.Add(name);
                }));
            }
            TabComboBox.Invoke(new MethodInvoker(delegate {
                TabComboBox.SelectedIndex = 0;
            }));

            LoadDataForItem(m_Bank.BankTabs[0].ItemsDictionary.First().Value.ItemID);

            BankListBox.Invoke(new MethodInvoker(delegate {
                BankListBox.SelectedIndex = 0;
            }));

            if ( UpdateTable ) { LoadDataForBankTable(); }
            
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
                    BankItemManage.Visible = true;
                    ManagementToolsBox.Visible = true;

                    EventItemsList.SelectionMode = SelectionMode.One;

                    m_PollPendingTimer = new System.Timers.Timer(50000); // 1 sec = 1000, 60 sec = 60000
                    m_PollPendingTimer.AutoReset = true;
                    m_PollPendingTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateDataForBankTable);
                    m_PollPendingTimer.Start();
                }
            }
            if( eventName == "BankItemSelected")
            {
                LoadDataForItem((obj as Item).ItemID);
            }
            if( eventName == "DeleteFromBank")
            {
                DeleteItemFromBank(TabComboBox.SelectedIndex, (obj as Item).ItemID, (obj as Item).StackSize);
            }
            if( eventName == "ApprovePending")
            {
                // update document
                RemoveItemFromPendingXML((obj as Item));
                // add to bank
                SendItemToBank((obj as Item), (obj as Item).StackSize);
                // refresh list
                LoadDataForBankList(true);

                BankListBox.Invalidate();
            }
            if (eventName == "RefreshBankList")
            {
                LoadDataForBankList(true);
                BankListBox.Invalidate();
            }
        }

        private void TabComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_SelectedBankTab = TabComboBox.SelectedIndex;
            LoadDataForBankTable();
        }

        private void UpdateDataForBankTable(object sender, System.Timers.ElapsedEventArgs e)
        {
            LoadDataForBankList(true);
            BankListBox.Invoke(new MethodInvoker(delegate {
                BankListBox.Invalidate();
            }));
        }

        private void LoadDataForBankTable()
        {
            BankListBox.Invoke(new MethodInvoker(delegate {
                BankListBox.Items.Clear();
            }));

            DisplayedBankItems = RetreaveXMLPendingSubmissions();

            if (m_SelectedBankTab < m_Bank.BankTabs.Count)
            {
                if (m_Bank.BankTabs[m_SelectedBankTab].ItemsDictionary == null) { return; }

                int count = m_Bank.BankTabs[m_SelectedBankTab].ItemsDictionary.Count;

                foreach (Item item in m_Bank.BankTabs[m_SelectedBankTab].ItemsDictionary.Values)
                {
                    DisplayedBankItems.Add(item);
                }
            }

            int row = 0;
            foreach (Item item in DisplayedBankItems)
            {
                RowStyle style = new RowStyle(SizeType.Percent);
                style.Height = 10;
                CellForItemList cell = new CellForItemList(item);


                BankListBox.Invoke(new MethodInvoker(delegate {
                    //BankListBox.RowStyles.Add(style);
                    BankListBox.Items.Add(item.StackSize + "\t::\t" + item.Name);
                }));

                row++;
            }
        }

        private void OpenPendingXMLDoc(FileStream fs)
        {
            if (m_PendingXMLDoc == null)
            {
                m_PendingXMLDoc = new XmlDocument();
            }

            m_PendingXMLDoc.Load(fs);
        }

        private List<Item> RetreaveXMLPendingSubmissions()
        {
            List<Item> retList = new List<Item>();

            if (User.Instance.Rank == MemberRanks.MEMBER)
            {
                return retList;
            }

            FileStream fs = new FileStream(AddonPathTextBox.Text + "\\ParsedSubmissionsToGuildBank.xml", FileMode.Open, FileAccess.Read);
            OpenPendingXMLDoc(fs);
            XmlNodeList xmlnode;

            xmlnode = m_PendingXMLDoc.GetElementsByTagName("Submission");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                string submitter = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                int itemID = Convert.ToInt32(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                int stackSize = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());
                string itemName = xmlnode[i].ChildNodes.Item(5).InnerText.Trim();

                Item item = new Item(itemID, itemName);
                item.StackSize = stackSize;
                item.Sender = submitter;
                item.Pending = true;

                retList.Add(item);
            }
            fs.Close();
            return retList;
            /**/
        }

        private void RemoveItemFromPendingXML(Item item)
        {
            FileStream fs = new FileStream(AddonPathTextBox.Text + "\\ParsedSubmissionsToGuildBank.xml", FileMode.Open, FileAccess.ReadWrite);
            OpenPendingXMLDoc(fs);
            XmlNodeList xmlnode;
                       
            xmlnode = m_PendingXMLDoc.GetElementsByTagName("Submission");
            int i = 0;
            for (; i <= xmlnode.Count - 1; i++)
            {
                string submitter = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                int itemID = Convert.ToInt32(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                int stackSize = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());
                string itemName = xmlnode[i].ChildNodes.Item(5).InnerText.Trim();
                
                if( submitter == item.Sender &&
                    itemID == item.ItemID &&
                    stackSize == item.StackSize &&
                    itemName == item.Name )
                {
                    xmlnode[i].ParentNode.RemoveChild(xmlnode[i]);
                    break;
                }
            }
            fs.Close();

            StreamWriter sw = new StreamWriter(AddonPathTextBox.Text + "\\ParsedSubmissionsToGuildBank.xml");
            m_PendingXMLDoc.Save(sw);
            sw.Close();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 1)
            {
                LoadDataForEvent();
                LoadUserForEvent();
            }
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


            EventItemsList.Items.Clear();

            int row = 0;
            foreach (Item item in m_Event.WinnableItems.Values)
            {
                RowStyle style = new RowStyle(SizeType.Percent);
                style.Height = 10;

                Label label = new Label();
                label.Text = item.Name;
                EventItemsList.Items.Add(item.Name);

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
            if (m_Event == null)
            {
                m_Event = new Event();
            }
            m_Event.Submissions = Entries;

            int entries = 0;
            if (m_Event.Submissions.ContainsKey(User.Instance.Username)) {
                entries = m_Event.Submissions[User.Instance.Username];
            }

            CurrentEventEntries.Text = "Number of Tickets in Current Event: " + entries.ToString();
            BankedTicketsLabel.Text = User.Instance.Username + ", you have " + User.Instance.EntryTokens.ToString() + " tickets to spend.";


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (User.Instance.EntryTokens > 0)
            {
                SubmitToEvent(1);
            } else
            {
                MessageBox.Show("You don't have any tickets. Try submitting a valued item to the guild bank first.", "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (User.Instance.EntryTokens >= Convert.ToInt32(eventTokenSubmissionCount.Value))
            {
                SubmitToEvent(Convert.ToInt32(eventTokenSubmissionCount.Value));
            }
            else
            {
                MessageBox.Show("You don't have enough tickets for that.", "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        async private void DeleteItemFromBank(int tab, int id, int count)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Bank//" + string.Format("{0}//{1}//{2}", tab, id, count);
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

        async private void SendItemToBank(Item item, int count)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Bank//AddItem//";
            HttpResponseMessage retsz;
            try
            {
                retsz = await client.PutAsJsonAsync<Item>(path, item);
            }
            catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BankListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForItem(DisplayedBankItems[BankListBox.SelectedIndex].ItemID);
        }

        private void BankItemManage_Click(object sender, EventArgs e)
        {
            if (BankListBox.SelectedIndex < DisplayedBankItems.Count && BankListBox.SelectedIndex >= 0)
            {
                BankManagementPopup page = new BankManagementPopup();
                page.InitializeMe(DisplayedBankItems[BankListBox.SelectedIndex]);
                page.Show(this);
            }
        }

        private void EventItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItemLabel.Text = EventItemsList.Items[EventItemsList.SelectedIndex] as string;
        }

        private void EventWinnerButton_Click(object sender, EventArgs e)
        {
            List<String> submissions = new List<string>();
            foreach(string submission in m_Event.Submissions.Keys)
            {
                for (int i = 0; i < m_Event.Submissions[submission]; i++)
                {
                    submissions.Add(submission);
                }
            }

            Random r = new Random();
            EventWinnerLabel.Text = submissions[r.Next(0, submissions.Count)];
            RemoveSubmissionFromEvent(EventWinnerLabel.Text, m_Event.Submissions[EventWinnerLabel.Text]);
        }

        private void RemoveEventItemButton_Click(object sender, EventArgs e)
        {
            RemoveItemFromEvent(EventItemsList.Items[EventItemsList.SelectedIndex] as string);
        }

        async private void RemoveItemFromEvent(string itemName)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Event//RemoveItem//" + itemName;
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

            LoadDataForEvent();
        }

        async private void RemoveSubmissionFromEvent(string itemName, int count)
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += string.Format("//Event//RemoveSubmission//{0}//{1}", itemName,count);
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

            LoadUserForEvent();
        }
    }
}
