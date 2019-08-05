using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OGREAPI.Controllers;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using OGRE.Events;

namespace OGRE
{
    public partial class BankManagementPopup : Form
    {
        public Item workingItem;

        public BankManagementPopup()
        {
            InitializeComponent();
        }

        public void InitializeMe(Item item)
        {
            workingItem = item;
            if (!workingItem.Pending)
            {
                ApproveButton.Enabled = false;
            }

            LoadDataForItem();

            this.Text = workingItem.Name;
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            EventSystem.Instance.TriggerEvent("ApprovePending", workingItem);
            this.Close();
        }

        private void AddItemToEventButton_Click(object sender, EventArgs e)
        {
            AddItemToEvent();
            this.Close();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            Item item = new Item(workingItem, (int)StackCountNumericUpDown.Value);
            EventSystem.Instance.TriggerEvent("DeleteFromBank", item);
            this.Close();
        }


        async public void LoadDataForItem()
        {
            HttpClient client = new HttpClient();
            string path = string.Format("https://www.wowhead.com/item={0}&xml", workingItem.ItemID);
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
            //var icon = xDoc.Descendants("icon").Single();
            //Uri uri = new Uri(string.Format("https://wow.zamimg.com/images/wow/icons/large/{0}.jpg", icon.Value));
            //this.Icon = new Icon(new System.IO.Stream());
            this.Text = xDoc.Descendants("name").Single().Value;

            StackCountNumericUpDown.Value = workingItem.StackSize;
        }

        async public void AddItemToEvent()
        {
            HttpClient client = new HttpClient();
            string path = "https://localhost:44320//api";
            path += "//Event//AddItem//" + workingItem.ItemID.ToString();
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

            EventSystem.Instance.TriggerEvent<Item>("RefreshBankList", null);
        }
    }
}
