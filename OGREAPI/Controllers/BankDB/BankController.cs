 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace OGREAPI.Controllers
{
    [Route("api/Bank")]
    [ApiController]
    public class BankController : ControllerBase
    {
        // GET api/Bank
        [HttpGet("{rank}")]
       // public ActionResult<IEnumerable<string>> Get()
        public ActionResult<string> Get(int rank)
        {
            //return JsonConvert.SerializeObject(BankDatabase.Instance.m_Bank);
            return BankDatabase.Instance.GetBankAsJSON(rank);
        }

        // GET api/values/5
        [HttpGet("{rank}/{id}")]
        public ActionResult<string> Get(int rank, int id)
        {
            Item item = BankDatabase.Instance.GetItemWithID(id);
            if( item == null )
            {
                return "Error: No item found";
            }
            return item.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromForm] Dictionary<string, string> value)
        {
            Item item = new Item(Convert.ToInt32(value["ID"]), value["Name"]);
            BankDatabase.Instance.AddItemToBankTab(item, Convert.ToInt32(value["Tab"]));
        }

        // POST api/values
        [HttpPost("AddTab/{tabName}")]
        public void Post(string tabName)
        {
            BankDatabase.Instance.CreateAdditionalTab(tabName);
        }

        // POST api/values
        [HttpPost("SetTabNam/{tabIndex}/{tabName}")]
        public void Post(int tabIndex, string tabName)
        {
            BankDatabase.Instance.SetTabName(tabIndex, tabName);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Item item = new Item(id, value);
            BankDatabase.Instance.AddItemToBankTab(item, 0);
        }

        [HttpGet("Key/{bankkey}")]
        public void Put(string bankkey)
        {
            BankDatabase.Instance.BankKey = bankkey;
        }

        [HttpGet("Key")]
        public ActionResult<string> GetKey()
        {
            if( BankDatabase.Instance.BankKey != null)
            {
                return BankDatabase.Instance.BankKey;
            }
            return "NoKey";
        }

        [HttpPut("AddItem")]
        public void PutNewItem([FromBody] Item item)
        {
            BankDatabase.Instance.AddItemToBankTab(item, 0);
        }

        // DELETE api/values/1/103/1
        [HttpDelete("{tab}/{id}/{count}")]
        public ActionResult<string> Delete(int tab, int id, int count)
        {
            if( BankDatabase.Instance.RemoveItem(id, tab, count) )
            {
                return "Still Available";
            }
            return "Deleted";
        }
    }
}
