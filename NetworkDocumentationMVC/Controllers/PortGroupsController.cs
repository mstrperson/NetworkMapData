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
    public class PortGroupsController : Controller
    {
        private NetworkDataEntities db = new NetworkDataEntities();

        // GET: PortGroups
        public ActionResult Index()
        {
            return View(db.PortGroups.ToList());
        }

        // GET: PortGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortGroup portGroup = db.PortGroups.Find(id);
            if (portGroup == null)
            {
                return HttpNotFound();
            }
            return View(portGroup);
        }

        // GET: PortGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Notes")] PortGroup portGroup)
        {
            if (ModelState.IsValid)
            {
                db.PortGroups.Add(portGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portGroup);
        }

        // GET: PortGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortGroup portGroup = db.PortGroups.Find(id);
            if (portGroup == null)
            {
                return HttpNotFound();
            }
            return View(portGroup);
        }

        // POST: PortGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Notes")] PortGroup portGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portGroup);
        }

        // GET: PortGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortGroup portGroup = db.PortGroups.Find(id);
            if (portGroup == null)
            {
                return HttpNotFound();
            }
            return View(portGroup);
        }

        // POST: PortGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortGroup portGroup = db.PortGroups.Find(id);
            db.PortGroups.Remove(portGroup);
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
