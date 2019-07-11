using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGREAPI.Controllers
{
    [Serializable]
    public class Bank
    {
        public List<Grouping> BankTabs;
        public int VersionNumber;
        public int WrapVersionNumber = 1024;

        public Bank()
        {
            BankTabs = new List<Grouping>();
            
        }
    }
}
