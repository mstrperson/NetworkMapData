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
    public class SwitchesController : Controller
    {
        private NetworkDataEntities db = new NetworkDataEntities();

        // GET: Switches
        public ActionResult Index()
        {
            var switches = db.Switches.Include(s => s.Closet);
            return View(switches.ToList());
        }

        // GET: Switches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = db.Switches.Find(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            return View(@switch);
        }

        // GET: Switches/Create
        public ActionResult Create()
        {
            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name");
            return View();
        }

        // POST: Switches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ModelInfo,ClosetId")] Switch @switch)
        {
            if (ModelState.IsValid)
            {
                db.Switches.Add(@switch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name", @switch.ClosetId);
            return View(@switch);
        }

        // GET: Switches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = db.Switches.Find(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name", @switch.ClosetId);
            return View(@switch);
        }

        // POST: Switches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ModelInfo,ClosetId")] Switch @switch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@switch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name", @switch.ClosetId);
            return View(@switch);
        }

        // GET: Switches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = db.Switches.Find(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            return View(@switch);
        }

        // POST: Switches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Switch @switch = db.Switches.Find(id);
            db.Switches.Remove(@switch);
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
