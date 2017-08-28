using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using parkovka14.Models;

namespace parkovka14.Controllers
{
    public class Points1Controller : Controller
    {
        private DataContext db = new DataContext();

        // GET: Points1
        public async Task<ActionResult> Index()
        {
            return View(await db.Points.ToListAsync());
        }

        // GET: Points1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point point = await db.Points.FindAsync(id);
            if (point == null)
            {
                return HttpNotFound();
            }
            return View(point);
        }

        // GET: Points1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Points1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Traffic,Cash,GeoLong,GeoLat")] Point point)
        {
            if (ModelState.IsValid)
            {
                db.Points.Add(point);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(point);
        }

        // GET: Points1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point point = await db.Points.FindAsync(id);
            if (point == null)
            {
                return HttpNotFound();
            }
            return View(point);
        }

        // POST: Points1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Traffic,Cash,GeoLong,GeoLat")] Point point)
        {
            if (ModelState.IsValid)
            {
                db.Entry(point).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(point);
        }

        // GET: Points1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point point = await db.Points.FindAsync(id);
            if (point == null)
            {
                return HttpNotFound();
            }
            return View(point);
        }

        // POST: Points1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Point point = await db.Points.FindAsync(id);
            db.Points.Remove(point);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
