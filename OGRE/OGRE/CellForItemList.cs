using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OGREAPI.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using OGRE.Events;

namespace OGRE
{
    class CellForItemList : Panel
    {
        Item baseItem;

        public CellForItemList(Item _item)
        {
            baseItem = _item;
            Dock = DockStyle.Fill;
            BackColor = Color.SlateGray;

            if(baseItem == null)
            {
                return;
            }

            Label label = new Label();
            label.Text = baseItem.Name + "        x" + baseItem.StackSize.ToString();
            label.Dock = DockStyle.Fill;
            label.Click += delegate (object sender2, EventArgs e2)
            { BankItemSelect(sender2, e2, baseItem); };
            this.Controls.Add(label);

            if (User.Instance.Rank != MemberRanks.MEMBER)
            {
                Button mngbtn = new Button();
                mngbtn.Size = new Size(32, 32);
                mngbtn.Dock = DockStyle.Right;
                mngbtn.BackColor = Color.Azure;
                mngbtn.Click += delegate (object sender3, EventArgs e3)
                { BankManagementPopupClicked(sender3, e3, baseItem); };
                this.Controls.Add(mngbtn);

                if (baseItem.Pending)
                {
                    BackColor = Color.Yellow;
                }
            }
        }
        protected void BankItemSelect(object sender, EventArgs e, Item item)
        {
            EventSystem.Instance.TriggerEvent("BankItemSelected", item);
        }

        private void BankManagementPopupClicked(object sender, EventArgs e, Item item)
        {
            BankManagementPopup page = new BankManagementPopup();
            page.InitializeMe(item);
            page.Show(this);
        }
    }
}
