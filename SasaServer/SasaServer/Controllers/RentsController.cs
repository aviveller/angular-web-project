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
using SasaServer.Models;

namespace SasaServer.Controllers
{
    public class RentsController : ApiController
    {
        private SaSaDBEntities db = new SaSaDBEntities();

        // GET: api/Rents
        public IQueryable<Rent> GetRent()
        {
            return db.Rent;
        }

    [Route("api/Rents/{taken}/{ret}/{location}")]
    [ResponseType(typeof(Rent))]
    public IHttpActionResult GetByDate(int taken, int ret, int location)
    {
      Rent test = db.Rent.Find(location);

      if (test == null)
      {
        return NotFound();
      }

      return Ok(test);
    }


    // GET: api/Rents/5
    [ResponseType(typeof(Rent))]
        public IHttpActionResult GetRent(int id)
        {
            Rent rent = db.Rent.Find(id);
            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        // PUT: api/Rents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRent(int id, Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rent.Id)
            {
                return BadRequest();
            }

            db.Entry(rent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        [ResponseType(typeof(Rent))]
        public IHttpActionResult PostRent(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rent.Add(rent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RentExists(rent.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rent.Id }, rent);
        }

        // DELETE: api/Rents/5
        [ResponseType(typeof(Rent))]
        public IHttpActionResult DeleteRent(int id)
        {
            Rent rent = db.Rent.Find(id);
            if (rent == null)
            {
                return NotFound();
            }

            db.Rent.Remove(rent);
            db.SaveChanges();

            return Ok(rent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentExists(int id)
        {
            return db.Rent.Count(e => e.Id == id) > 0;
        }
    }
}
