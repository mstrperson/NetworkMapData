using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetworkMapData;

namespace NetworkDocumentationMVC.Controllers
{
    public class ClosetsController : Controller
    {
        private NetworkDataEntities db = new NetworkDataEntities();

        // GET: Closets
        public ActionResult Index()
        {
            var closets = db.Closets.Include(c => c.Area);
            return View(closets.ToList());
        }

        // GET: Closets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closet closet = db.Closets.Find(id);
            if (closet == null)
            {
                return HttpNotFound();
            }
            return View(closet);
        }

        // GET: Closets/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Name");
            return View();
        }

        // POST: Closets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,AreaId")] Closet closet)
        {
            if (ModelState.IsValid)
            {
                db.Closets.Add(closet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Name", closet.AreaId);
            return View(closet);
        }

        // GET: Closets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closet closet = db.Closets.Find(id);
            if (closet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Name", closet.AreaId);
            return View(closet);
        }

        // POST: Closets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,AreaId")] Closet closet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Name", closet.AreaId);
            return View(closet);
        }

        // GET: Closets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closet closet = db.Closets.Find(id);
            if (closet == null)
            {
                return HttpNotFound();
            }
            return View(closet);
        }

        // POST: Closets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Closet closet = db.Closets.Find(id);
            db.Closets.Remove(closet);
            db.SaveChanges();
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
