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
    public partial class LoginPage : Form
    {
        public HttpClient client;
        private User user;
        public LoginPage()
        {
            InitializeComponent();
            client = new HttpClient();

            //load in preferences from save file
            //   if keep me logged in is On then fill username/password and Login(User.Instance.Username, User.Instance.Password, User.Instance.Version);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            User.Instance.Username = UsernameTextBox.Text;
            User.Instance.Password = PasswordTextBox.Text;
            User.Instance.Version = 1;

            Login(User.Instance.Username, User.Instance.Password, User.Instance.Version);
        }


        async void Login(string username, string password, int version)
        {
            string path = "https://localhost:44320//api";
            path += "//User//" + username + "//" + password + "//" + version.ToString();
            string retsz = "";

            retsz = await client.GetStringAsync(path);

            string[] split = new string[';'];
            string[] retArray = retsz.Split(';');

            if (retArray.Count() > 0 && retArray[0] == "Success")
            {
                switch (retArray[1])
                {
                    case "MEMBER":
                        User.Instance.Rank = MemberRanks.MEMBER;
                        break;
                    case "GUILD_LEADER":
                        User.Instance.Rank = MemberRanks.GUILD_LEADER;
                        break;
                    case "GUILD_MASTER":
                        User.Instance.Rank = MemberRanks.GUILD_MASTER;
                        break;
                }

                if( LoggedInCheckBox.Checked )
                {
                    // save info to save file
                }

                this.Close();
            } else
            {
                MessageBox.Show(retArray[0], "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
