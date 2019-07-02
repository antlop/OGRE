using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace OGREAPI.Controllers
{
    [Route("api/Bank")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/Bank
        [HttpGet("{rank}")]
       // public ActionResult<IEnumerable<string>> Get()
        public ActionResult<string> Get(int rank)
        {
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Item item = new Item(id, value);
            BankDatabase.Instance.AddItemToBankTab(item, 0);
        }

        // DELETE api/values/1/103/1
        [HttpDelete("{tab}/{id}/{count}")]
        public void Delete(int tab, int id, int count)
        {
            BankDatabase.Instance.RemoveItem(id, tab, count);
        }
    }
}
