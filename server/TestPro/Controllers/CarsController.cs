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
    public class CarsController : ApiController
    {
        private testdbEntities db = new testdbEntities();

        // GET: api/Cars
        public IQueryable<Cars> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Cars))]
        public async Task<IHttpActionResult> GetCars(int id)
        {
            Cars cars = await db.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCars(int id, Cars cars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cars.Id)
            {
                return BadRequest();
            }

            db.Entry(cars).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Cars))]
        public async Task<IHttpActionResult> PostCars(Cars cars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(cars);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarsExists(cars.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cars.Id }, cars);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Cars))]
        public async Task<IHttpActionResult> DeleteCars(int id)
        {
            Cars cars = await db.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }

            db.Cars.Remove(cars);
            await db.SaveChangesAsync();

            return Ok(cars);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarsExists(int id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}