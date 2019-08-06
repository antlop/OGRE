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

namespace OGRE
{
    public partial class LoginPage : Form
    {
        public HttpClient client;
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

            //EventSystem.Instance.TriggerEvent<Form>("LoginEvent", null);
            //this.Close();
            //return;


            string path = "https://localhost:44320//api";
            path += "//User//" + username + "//" + password + "//" + version.ToString();
            string retsz = "";
            try
            {
                retsz = await client.GetStringAsync(path);
            } catch
            {
                MessageBox.Show("There was an issue, Try again later.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                EventSystem.Instance.TriggerEvent<Form>("LoginEvent", null);
                this.Close();
            } else
            {
                MessageBox.Show(retArray[0], "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadBinaryUserData() {

            try
            {
                string path = "C:\\Program Files (x86)\\World of Warcraft\\_classic_\\Interface\\AddOns\\OGRE";

                bool exists = System.IO.Directory.Exists(path);

                if(!exists) {
                    return;
                }

                FileStream fs = File.Create(path + "\\pfile.dat", 2048, FileOptions.None);
                BinaryReader br = new BinaryReader(fs);

                string s = br.ReadLine().ToString();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(s);

                bw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.ReadKey(true);
            }
        }

        private void SaveBinaryUserData() {

            try
            {
                string path = "C:\\Program Files (x86)\\World of Warcraft\\_classic_\\Interface\\AddOns\\OGRE";

                bool exists = System.IO.Directory.Exists(path);

                if(!exists) {
                    System.IO.Directory.CreateDirectory(path);
                }

                FileStream fs = File.Create(path + "\\pfile.dat", 2048, FileOptions.None);
                BinaryWriter bw = new BinaryWriter(fs);

                string s = User.Instance.Name + ";" + User.Instance.Password;

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(s);

                bw.Write(ba);

                bw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.ReadKey(true);
            }
        }
    }
}
