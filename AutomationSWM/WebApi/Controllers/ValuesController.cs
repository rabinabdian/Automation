using AutomationSWM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {

        AutomationDBEntities2 db = new AutomationDBEntities2();
        TEST_STATUS_TB tb = new TEST_STATUS_TB();

        // GET api/values
        //public List<TEST_STATUS_TB>/*IEnumerable<string>*/ Get()
        //{
        //    //return new string[] { "value1", "value2" };



        //   // return List(db.TEST_STATUS_TB.OrderByDescending(c => c.Creation_Time)/*.Take(10)*/.ToList());
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
