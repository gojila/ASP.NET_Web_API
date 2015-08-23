using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Test_CORS.Models;

namespace Test_CORS.Controllers
{
    public class MobileController : ApiController
    {
        private AngulaJS_ExampleEntities db = new AngulaJS_ExampleEntities();

        // GET api/Mobile
        public IQueryable<MOBILE> GetMOBILE()
        {
            return db.MOBILE;
        }

        // GET api/Mobile/5
        [ResponseType(typeof(MOBILE))]
        public IHttpActionResult GetMOBILE(string id)
        {
            MOBILE mobile = db.MOBILE.Find(id);
            if (mobile == null)
            {
                return NotFound();
            }

            return Ok(mobile);
        }

        // PUT api/Mobile/5
        public IHttpActionResult PutMOBILE(string id, MOBILE mobile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobile.id)
            {
                return BadRequest();
            }

            db.Entry(mobile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MOBILEExists(id))
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

        // POST api/Mobile
        [ResponseType(typeof(MOBILE))]
        public IHttpActionResult PostMOBILE(MOBILE mobile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MOBILE.Add(mobile);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MOBILEExists(mobile.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mobile.id }, mobile);
        }

        // DELETE api/Mobile/5
        [ResponseType(typeof(MOBILE))]
        public IHttpActionResult DeleteMOBILE(string id)
        {
            MOBILE mobile = db.MOBILE.Find(id);
            if (mobile == null)
            {
                return NotFound();
            }

            db.MOBILE.Remove(mobile);
            db.SaveChanges();

            return Ok(mobile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MOBILEExists(string id)
        {
            return db.MOBILE.Count(e => e.id == id) > 0;
        }
    }
}