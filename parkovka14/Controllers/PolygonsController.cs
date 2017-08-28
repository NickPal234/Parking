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
using parkovka14.Models;

namespace parkovka14.Controllers
{
    public class PolygonsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Polygons
        public IQueryable<Polygon> GetPolygons()
        {
            return db.Polygons;
        }

        // GET: api/Polygons/5
        [ResponseType(typeof(Polygon))]
        public async Task<IHttpActionResult> GetPolygon(int id)
        {
            Polygon polygon = await db.Polygons.FindAsync(id);
            if (polygon == null)
            {
                return NotFound();
            }

            return Ok(polygon);
        }

        // PUT: api/Polygons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPolygon(int id, Polygon polygon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != polygon.Id)
            {
                return BadRequest();
            }

            db.Entry(polygon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolygonExists(id))
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

        // POST: api/Polygons
        [ResponseType(typeof(Polygon))]
        public async Task<IHttpActionResult> PostPolygon(Polygon polygon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Polygons.Add(polygon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = polygon.Id }, polygon);
        }

        // DELETE: api/Polygons/5
        [ResponseType(typeof(Polygon))]
        public async Task<IHttpActionResult> DeletePolygon(int id)
        {
            Polygon polygon = await db.Polygons.FindAsync(id);
            if (polygon == null)
            {
                return NotFound();
            }

            db.Polygons.Remove(polygon);
            await db.SaveChangesAsync();

            return Ok(polygon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolygonExists(int id)
        {
            return db.Polygons.Count(e => e.Id == id) > 0;
        }
    }
}