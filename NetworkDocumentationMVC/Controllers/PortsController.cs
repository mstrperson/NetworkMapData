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
    public class PortsController : Controller
    {
        private NetworkDataEntities db = new NetworkDataEntities();

        // GET: Ports
        public ActionResult Index()
        {
            return View(db.Ports.ToList());
        }

        // GET: Ports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Port port = db.Ports.Find(id);
            if (port == null)
            {
                return HttpNotFound();
            }
            return View(port);
        }

        // GET: Ports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Notes")] Port port)
        {
            if (ModelState.IsValid)
            {
                db.Ports.Add(port);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(port);
        }

        // GET: Ports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Port port = db.Ports.Find(id);
            if (port == null)
            {
                return HttpNotFound();
            }
            return View(port);
        }

        // POST: Ports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Notes")] Port port)
        {
            if (ModelState.IsValid)
            {
                db.Entry(port).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(port);
        }

        // GET: Ports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Port port = db.Ports.Find(id);
            if (port == null)
            {
                return HttpNotFound();
            }
            return View(port);
        }

        // POST: Ports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Port port = db.Ports.Find(id);
            db.Ports.Remove(port);
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
