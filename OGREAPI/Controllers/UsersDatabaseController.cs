using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace OGREAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UsersDatabaseController
    {
        // GET api/User
        [HttpGet("{username}/{password}/{version}")]
        public ActionResult<string> Get(string username, string password, int version)
        {
            if( !UserDatabase.Instance.UsersDB.ContainsKey(username) )
            {
                return "Username";
            }
            if( UserDatabase.Instance.UsersDB[username].Password.Equals(password) )
            {
                string ret = "Success;" + UserDatabase.Instance.UsersDB[username].Rank.ToString();
                if( UserDatabase.Instance.UsersDB[username].BankVersion != BankDatabase.Instance.GetBankVersionNumber())
                {
                    ret += ";Reload";
                }
                return ret;
            }

            return "Password";
        }

        // POST api/User
        [HttpGet("Create/{username}/{password}")]
        public ActionResult<string> Get(string username, string password)
        {
            //Item item = new Item(Convert.ToInt32(value["ID"]), value["Name"]);
            User user = new User(username, password, BankDatabase.Instance.GetBankVersionNumber());
            if( UserDatabase.Instance.UsersDB.ContainsKey(user.Name) )
            {
                return "Username";
            }

            UserDatabase.Instance.UsersDB.Add(user.Name, user);
            return "Success";
        }

        // POST api/User
        [HttpGet("CreateRanked/{rank}/{username}/{password}")]
        public ActionResult<string> Get(int rank, string username, string password)
        {
            //Item item = new Item(Convert.ToInt32(value["ID"]), value["Name"]);
            User user = new User(username, password, BankDatabase.Instance.GetBankVersionNumber());
            user.Rank = (MemberRanks)rank;
            if (UserDatabase.Instance.UsersDB.ContainsKey(user.Name))
            {
                return "Username";
            }

            UserDatabase.Instance.UsersDB.Add(user.Name, user);
            return "Success";
        }
    }
}
