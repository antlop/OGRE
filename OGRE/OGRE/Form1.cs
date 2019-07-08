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

namespace OGRE
{
    public partial class MainPage : Form
    {
        string Username;
        string Password;
        public HttpClient client;

        public MainPage()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            Login(username, password);
        }
        
        async Task<string> Login(string username, string password)
        {
            string path = "https://localhost:44320//api";
            path += "//User//" + username + "//" + password + "//1";
            string retsz = "";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                retsz = await response.Content.ReadAsAsync<string>();
                ResponseBox.Text = response.Content.ToString();
            }
            return retsz;
        }
    }
}
