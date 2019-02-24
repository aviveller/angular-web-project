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
    public class RantsController : ApiController
    {
        private testdbEntities db = new testdbEntities();

        // GET: api/Rants
        public IQueryable<Rant> GetRant()
        {
            return db.Rant;
        }

        // GET: api/Rants/5
        [ResponseType(typeof(Rant))]
        public async Task<IHttpActionResult> GetRant(int id)
        {
            Rant rant = await db.Rant.FindAsync(id);
            if (rant == null)
            {
                return NotFound();
            }

            return Ok(rant);
        }

        // PUT: api/Rants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRant(int id, Rant rant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rant.Id)
            {
                return BadRequest();
            }

            db.Entry(rant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RantExists(id))
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

        // POST: api/Rants
        [ResponseType(typeof(Rant))]
        public async Task<IHttpActionResult> PostRant(Rant rant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rant.Add(rant);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RantExists(rant.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rant.Id }, rant);
        }

        // DELETE: api/Rants/5
        [ResponseType(typeof(Rant))]
        public async Task<IHttpActionResult> DeleteRant(int id)
        {
            Rant rant = await db.Rant.FindAsync(id);
            if (rant == null)
            {
                return NotFound();
            }

            db.Rant.Remove(rant);
            await db.SaveChangesAsync();

            return Ok(rant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RantExists(int id)
        {
            return db.Rant.Count(e => e.Id == id) > 0;
        }
    }
}