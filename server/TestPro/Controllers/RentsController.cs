using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestPro;

namespace TestPro.Controllers
{
    public class RentsController : ApiController
    {
        private testdbEntities db = new testdbEntities();

        // GET: api/Rents
        public IQueryable<Rent> GetRent()
        {
            return db.Rent;
        }

        // GET: api/Rents/5
        [ResponseType(typeof(Rent))]
        public async Task<IHttpActionResult> GetRent(int id)
        {
            Rent rent = await db.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        // PUT: api/Rents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRent(int id, Rent rent)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostRent(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rent.Add(rent);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> DeleteRent(int id)
        {
            Rent rent = await db.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            db.Rent.Remove(rent);
            await db.SaveChangesAsync();

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