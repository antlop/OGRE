using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using OGRE.Events;

namespace OGRE
{

    public partial class SignUpPage : Form
    {
        public HttpClient client;
        public SignUpPage()
        {
            InitializeComponent();
            client = new HttpClient();

            this.BringToFront();
            //load in preferences from save file
            //   if keep me logged in is On then fill username/password and Login(User.Instance.Username, User.Instance.Password, User.Instance.Version);

        }


        async void SignUp(string username, string password, string key)
        {
            string path = "https://localhost:44320//api";
            path += "//User//Create//" + username + "//" + password + "//" + key;
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
                // set user data
                UserTemp user = new UserTemp();
                user.name = UsernameTextBox.Text;
                user.password = PasswordTextBox.Text;

                // trigger event to log in
                EventSystem.Instance.TriggerEvent<UserTemp>("AccountCreationSuccess", user);

                this.Close();
            }
            else
            {
                MessageBox.Show(retsz, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SignUp(UsernameTextBox.Text, PasswordTextBox.Text, BankKeyTextBox.Text);
        }
    }

    public class UserTemp
    {
        public string name;
        public string password;
        public int submissions;
    }
}
