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
    public class ProductController : ApiController
    {
        private AngulaJS_ExampleEntities db = new AngulaJS_ExampleEntities();

        // GET api/Product
        public IQueryable<PRODUCT> GetPRODUCT()
        {
            return db.PRODUCT;
        }

        // GET api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult GetPRODUCT(int id)
        {
            PRODUCT product = db.PRODUCT.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT api/Product/5
        public IHttpActionResult PutPRODUCT(int id, PRODUCT product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTExists(id))
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

        // POST api/Product
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult PostPRODUCT(PRODUCT product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCT.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTExists(product.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.id }, product);
        }

        // DELETE api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult DeletePRODUCT(int id)
        {
            PRODUCT product = db.PRODUCT.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.PRODUCT.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTExists(int id)
        {
            return db.PRODUCT.Count(e => e.id == id) > 0;
        }
    }
}