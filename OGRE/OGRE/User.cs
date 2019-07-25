using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGRE
{
    public enum MemberRanks
    {
        MEMBER,
        GUILD_LEADER,
        GUILD_MASTER
    }
    public class User
    {
        public string Username;
        public string Password;
        public MemberRanks Rank;
        public int Version;
        public int EntryTokens;

        private static readonly Lazy<User>
            lazy =
            new Lazy<User>
                (() => new User());

        public static User Instance { get { return lazy.Value; } }

        private User()
        {
            Username = "";
            Password = "";
            Rank = MemberRanks.MEMBER;
            Version = 0;
            EntryTokens = 0;
        }
    }
}
