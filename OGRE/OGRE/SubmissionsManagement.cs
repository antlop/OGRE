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
    public partial class SubmissionsManagement : Form, IListener
    {
        public Event m_Event;
        public HttpClient client;

        public SubmissionsManagement()
        {
            InitializeComponent();
            client = new HttpClient();
            EventSystem.Instance.RegisterListenerForEvent("RefreshEventList", this);
        }

        public void InitializeMe(Event e)
        {
            m_Event = e;

            foreach(KeyValuePair<String, int> pair in m_Event.Submissions)
            {
                SubmissionsListBox.Items.Add(String.Format("Name: {0} {1,60}", pair.Key, "Entries: " + pair.Value));
            }
        }

        public void HandleEvent<T>(string eventName, T obj)
        {
            if( eventName == "RefreshEventList")
            {
                SubmissionsListBox.Items.Clear();
                foreach (KeyValuePair<String, int> pair in (obj as Dictionary<String, int>))
                {
                    SubmissionsListBox.Items.Add(String.Format("Name: {0} {1,60}", pair.Key, "Entries: " + pair.Value));
                }
                SubmissionsListBox.Invalidate();
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SubmitManualEntryButton_Click(object sender, EventArgs e)
        {
            SubmitEntryToEvent();
        }

        async private void SubmitEntryToEvent()
        {
            string path = "https://localhost:44320//api";
            path += "//Event//GrantSubmissionTokens//" + ManualEntryNameTextBox.Text + "//" + (int)ManualEntryNumberIncrementor.Value;
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
            if (retsz == "Success")
            {
                string path2 = "https://localhost:44320//api";
                path2 += "//Event//AddSubmission//" + ManualEntryNameTextBox.Text + "//" + (int)ManualEntryNumberIncrementor.Value;
                string retsz2 = "";
                try
                {
                    retsz2 = await client.GetStringAsync(path2);
                }
                catch
                {
                    MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (retsz2 == "Success")
                {
                    EventSystem.Instance.TriggerEvent<UserTemp>("RefreshEventData", null);
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SubtractFromUserSubmissions();
        }

        async private void SubtractFromUserSubmissions()
        {
            string path = "https://localhost:44320//api";
            path += "//Event//AddSubmission//" + ManualEntryNameTextBox.Text + "//" + (-1).ToString();
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

            if (retsz == "Success")
            {
                EventSystem.Instance.TriggerEvent<UserTemp>("RefreshEventData", null);
            }
        }
    }
}
