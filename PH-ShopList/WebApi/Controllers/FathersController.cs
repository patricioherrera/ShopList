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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class FathersController : ApiController
    {
        private ShopListContext db = new ShopListContext();

        // GET: api/Fathers
        public IQueryable<Father> GetFathers()
        {
            return db.Fathers;
        }

        // GET: api/Fathers/5
        [ResponseType(typeof(Father))]
        public IHttpActionResult GetFather(int id)
        {
            Father father = db.Fathers.Find(id);
            if (father == null)
            {
                return NotFound();
            }

            return Ok(father);
        }

        // PUT: api/Fathers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFather(int id, Father father)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != father.FatherId)
            {
                return BadRequest();
            }

            db.Entry(father).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FatherExists(id))
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

        // POST: api/Fathers
        [ResponseType(typeof(Father))]
        public IHttpActionResult PostFather(Father father)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fathers.Add(father);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = father.FatherId }, father);
        }

        // DELETE: api/Fathers/5
        [ResponseType(typeof(Father))]
        public IHttpActionResult DeleteFather(int id)
        {
            Father father = db.Fathers.Find(id);
            if (father == null)
            {
                return NotFound();
            }

            db.Fathers.Remove(father);
            db.SaveChanges();

            return Ok(father);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FatherExists(int id)
        {
            return db.Fathers.Count(e => e.FatherId == id) > 0;
        }
    }
}