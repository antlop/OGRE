using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    public class User
    {
        public string Name;
        public string Password;
        public int BankVersion;
        public MemberRanks Rank;
        public int EventTokens;

        public User(string name, string password, int bankversion, int eventTokens)
        {
            Name = name;
            Password = password;
            BankVersion = bankversion;
            Rank = MemberRanks.MEMBER;
            EventTokens = eventTokens;
        }

        public override string ToString()
        {
            return Name + ";" + Password + ";" + BankVersion.ToString() + ";" + Rank.ToString() + ";" + EventTokens.ToString();
        }
    }
}
