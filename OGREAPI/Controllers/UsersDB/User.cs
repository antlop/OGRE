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

        public User(string name, string password, int bankversion)
        {
            Name = name;
            Password = password;
            BankVersion = bankversion;
            Rank = MemberRanks.MEMBER;
        }
    }
}
