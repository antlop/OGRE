using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using OGRE.Events;
using OGREAPI.Controllers;
using Newtonsoft.Json;

using WowDotNetAPI;
using WowDotNetAPI.Models;

namespace OGRE
{
    public partial class MainPage : Form, IListener
    {
        public User user;
        public Bank m_Bank;
        WowExplorer m_Explorer;
        public MainPage()
        {
            InitializeComponent();
            user = User.Instance;

            LoginPage page = new LoginPage();
            page.Show(this);

            EventSystem.Instance.RegisterListenerForEvent("LoginEvent", this);

            //m_Explorer = new WowExplorer(WowDotNetAPI.Region.US, Locale.en_US, "732aa68878154a04964e12aed8fddfad");

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

            for (int index = 0; index < count; index++)
            {
                TabComboBox.Items.Add("Tab " + index.ToString());
            }
            TabComboBox.SelectedIndex = 0;
        }

        public void HandleEvent<T>(string eventName, T obj)
        {
            if (eventName == "LoginEvent")
            {
                MainTabControl.Visible = true;
                LoadDataForBankList();
            }
        }


        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("paint");
        }

        private void TabComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox send = (ComboBox)sender;
            int tabIndex = send.SelectedIndex;
            tableLayoutPanel2.Controls.Clear();
            if (tabIndex < m_Bank.BankTabs.Count)
            {
                int count = m_Bank.BankTabs[tabIndex].ItemsDictionary.Count;
                int col = 0;
                int row = 0;
                foreach (OGREAPI.Controllers.Item item in m_Bank.BankTabs[tabIndex].ItemsDictionary.Values)
                {
                    RowStyle style = new RowStyle(SizeType.Absolute);
                    style.Height = 80;
                    tableLayoutPanel2.RowStyles.Add(style);

                    Label label = new Label();
                    label.Text = item.Name;
                    tableLayoutPanel2.Controls.Add(label, col, row);

                    col++;
                    if (col == tableLayoutPanel2.ColumnCount)
                    {
                        col = 0;
                        row++;
                    }
                }
            }
        }

        private void EventTab_Paint(object sender, PaintEventArgs e)
        {
            LoadDataForEvent();
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

            var bank = JsonConvert.DeserializeObject<Bank>(retsz);
            /*m_Bank = bank;


            EventWinnableItemsList.Controls.Clear();

            foreach (OGREAPI.Controllers.Item item in m_Bank.BankTabs[tabIndex].ItemsDictionary.Values)
            {
                WowDotNetAPI.Models.Item truitem = m_Explorer.GetItem(00000002);
                RowStyle style = new RowStyle(SizeType.Absolute);
                style.Height = 80;
                tableLayoutPanel2.RowStyles.Add(style);

                Label label = new Label();
                label.Text = item.Name;
                tableLayoutPanel2.Controls.Add(label, col, row);

                col++;
                if (col == tableLayoutPanel2.ColumnCount)
                {
                    col = 0;
                    row++;
                }
            }
            
            */
        }
    }
}
