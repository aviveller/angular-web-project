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
    public class LocationsController : ApiController
    {
        private SaSaDBEntities db = new SaSaDBEntities();

        // GET: api/Locations
        public IQueryable<Location> GetLocation()
        {
            return db.Location;
        }

        // GET: api/Locations/5
        [ResponseType(typeof(Location))]
        public IHttpActionResult GetLocation(int id)
        {
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/Locations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.Id)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        [ResponseType(typeof(Location))]
        public IHttpActionResult PostLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Location.Add(location);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LocationExists(location.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [ResponseType(typeof(Location))]
        public IHttpActionResult DeleteLocation(int id)
        {
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            db.Location.Remove(location);
            db.SaveChanges();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return db.Location.Count(e => e.Id == id) > 0;
        }
    }
}