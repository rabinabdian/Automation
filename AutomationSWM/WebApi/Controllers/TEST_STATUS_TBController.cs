using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi;

namespace WebApi.Controllers
{

    [EnableCorsAttribute("http://localhost:12800", "*","*")]
    public class TEST_STATUS_TBController : ApiController
    {
         AutomationDBEntities2 db = new AutomationDBEntities2();

        // GET: api/TEST_STATUS_TB
        //public IQueryable<TEST_STATUS_TB> GetTEST_STATUS_TB()
        //{
        //    return db.TEST_STATUS_TB;
        //}


        public HttpResponseMessage GetTEST_STATUS_TB()
        {
            return ToJson(db.TEST_STATUS_TB);
        }

        private HttpResponseMessage ToJson(DbSet<TEST_STATUS_TB> obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }



        // GET: api/TEST_STATUS_TB/5
        [ResponseType(typeof(TEST_STATUS_TB))]
        public IHttpActionResult GetTEST_STATUS_TB(string id)
        {
            TEST_STATUS_TB tEST_STATUS_TB = db.TEST_STATUS_TB.Find(id);
            if (tEST_STATUS_TB == null)
            {
                return NotFound();
            }

            return Ok(tEST_STATUS_TB);
        }

        // PUT: api/TEST_STATUS_TB/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTEST_STATUS_TB(string id, TEST_STATUS_TB tEST_STATUS_TB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tEST_STATUS_TB.Test_ID)
            {
                return BadRequest();
            }

            db.Entry(tEST_STATUS_TB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TEST_STATUS_TBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TEST_STATUS_TB
        [ResponseType(typeof(TEST_STATUS_TB))]
        public IHttpActionResult PostTEST_STATUS_TB(TEST_STATUS_TB tEST_STATUS_TB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TEST_STATUS_TB.Add(tEST_STATUS_TB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TEST_STATUS_TBExists(tEST_STATUS_TB.Test_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tEST_STATUS_TB.Test_ID }, tEST_STATUS_TB);
        }

        // DELETE: api/TEST_STATUS_TB/5
        [ResponseType(typeof(TEST_STATUS_TB))]
        public IHttpActionResult DeleteTEST_STATUS_TB(string id)
        {
            TEST_STATUS_TB tEST_STATUS_TB = db.TEST_STATUS_TB.Find(id);
            if (tEST_STATUS_TB == null)
            {
                return NotFound();
            }

            db.TEST_STATUS_TB.Remove(tEST_STATUS_TB);
            db.SaveChanges();

            return Ok(tEST_STATUS_TB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TEST_STATUS_TBExists(string id)
        {
            return db.TEST_STATUS_TB.Count(e => e.Test_ID == id) > 0;
        }
    }
}