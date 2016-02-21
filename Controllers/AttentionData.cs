using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ClassMate.DBO;

namespace ClassMate.Controllers
{
    public class Headset {
        public int HeadsetID { get; set; }
        public int Attention { get; set; }
    }
    
    [Route("api/[controller]")]
    public class AttentionData : Controller {
        DBOHandler dboHandler = new DBOHandler();
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "Hello", "World"};
        }
        
        [HttpPost]
        public ActionResult Post([FromBody]Headset headset) {
            Console.WriteLine(headset.HeadsetID + " - " + headset.Attention);
            dboHandler.updatetHeadsetData(headset.HeadsetID, headset.Attention);
            return Json(new { success = true});
        }
    }
}

