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
            EventDatabase.Instance.AddSubmission(username);
            return "Success";
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
    }
}
