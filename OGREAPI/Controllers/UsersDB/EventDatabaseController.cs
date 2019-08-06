using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace OGREAPI.Controllers
{
    [Route("api/Event")]
    [ApiController]
    public class EventDatabaseController
    {
        // GET api/Event
        [HttpGet("AddSubmission/{username}")]
        public ActionResult<string> AddSubmission(string username)
        {
            return AddSubmissions(username, 1);
        }

        [HttpGet("AddSubmission/{username}/{count}")]
        public ActionResult<string> AddSubmissions(string username, int count)
        {
            if (UserDatabase.Instance.UsersDB.ContainsKey(username))
            {
                if (UserDatabase.Instance.UsersDB[username].EventTokens >= count)
                {
                    while (count > 0) { 
                        EventDatabase.Instance.AddSubmission(username);
                        count--;
                    }
                    UserDatabase.Instance.UsersDB[username].EventTokens -= count;

                    return "Success";
                }
                else
                {
                    return "Failure: Not Enough Tokens";
                }
            }
            else
            {
                return "Failure: User Not Found";
            }
        }

        [HttpGet("Clear/Submissions")]
        public ActionResult<string> ClearSubmissions()
        {
            EventDatabase.Instance.ResetSubmission();
            return "Success";
        }

        [HttpGet("Clear/Items")]
        public ActionResult<string> ClearItems()
        {
            EventDatabase.Instance.ResetItems();
            return "Success";
        }


        [HttpGet("Clear/All")]
        public ActionResult<string> ClearAll()
        {
            EventDatabase.Instance.ResetEvent();
            return "Success";
        }

        [HttpGet("AddItem/{itemId}")]
        public ActionResult<string> AddItem(int itemID)
        {
            Item item = new Item(BankDatabase.Instance.GetItemWithID(itemID), 1);
            if ( item != null)
            {
                EventDatabase.Instance.AddItem(item);
                return "Success";
            }
            return "Failure: Item not found in bank.";
        }

        [HttpGet()]
        public ActionResult<string> Get()
        {
            string json = EventDatabase.Instance.GetJSONWinnableItems();
            if (json != null && json.Length > 0)
            {
                return json;
            }
            return "Failure: JSON error";
        }

        [HttpGet("Entries")]
        public ActionResult<string> GetEntries()
        {
            string json = EventDatabase.Instance.GetJSONEntrys();
            if (json != null && json.Length > 0)
            {
                return json;
            }
            return "Failure: JSON error";
        }

        [HttpDelete("RemoveItem/{itemname}")]
        public ActionResult<string> RemoveItem(string itemname)
        {
            EventDatabase.Instance.RemoveItem(itemname);
            return "SUCCESS";
        }

        [HttpDelete("RemoveSubmission/{subname}/{count}")]
        public ActionResult<string> RemoveSubmission(string subname, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (!EventDatabase.Instance.RemoveSubmission(subname))
                {
                    break;
                }
            }
            return "SUCCESS";
        }
    }
}
