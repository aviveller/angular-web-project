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
    public class CatalogsController : ApiController
    {
        private SaSaDBEntities db = new SaSaDBEntities();

        // GET: api/Catalogs
        public IQueryable<Catalog> GetCatalog()
        {
            return db.Catalog;
        }

        // GET: api/Catalogs/5
        [ResponseType(typeof(Catalog))]
        public IHttpActionResult GetCatalog(int id)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalog(int id, Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalog.Id)
            {
                return BadRequest();
            }

            db.Entry(catalog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
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

        // POST: api/Catalogs
        [ResponseType(typeof(Catalog))]
        public IHttpActionResult PostCatalog(Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catalog.Add(catalog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CatalogExists(catalog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = catalog.Id }, catalog);
        }

        // DELETE: api/Catalogs/5
        [ResponseType(typeof(Catalog))]
        public IHttpActionResult DeleteCatalog(int id)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            db.Catalog.Remove(catalog);
            db.SaveChanges();

            return Ok(catalog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogExists(int id)
        {
            return db.Catalog.Count(e => e.Id == id) > 0;
        }
    }
}
