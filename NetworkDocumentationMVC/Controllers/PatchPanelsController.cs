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
    public class PatchPanelsController : Controller
    {
        private NetworkDataEntities db = new NetworkDataEntities();

        // GET: PatchPanels
        public ActionResult Index()
        {
            var patchPanels = db.PatchPanels.Include(p => p.Closet);
            return View(patchPanels.ToList());
        }

        // GET: PatchPanels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatchPanel patchPanel = db.PatchPanels.Find(id);
            if (patchPanel == null)
            {
                return HttpNotFound();
            }
            return View(patchPanel);
        }

        // GET: PatchPanels/Create
        public ActionResult Create()
        {
            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name");
            return View();
        }

        // POST: PatchPanels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ClosetId")] PatchPanel patchPanel)
        {
            if (ModelState.IsValid)
            {
                db.PatchPanels.Add(patchPanel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name", patchPanel.ClosetId);
            return View(patchPanel);
        }

        // GET: PatchPanels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatchPanel patchPanel = db.PatchPanels.Find(id);
            if (patchPanel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name", patchPanel.ClosetId);
            return View(patchPanel);
        }

        // POST: PatchPanels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ClosetId")] PatchPanel patchPanel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patchPanel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClosetId = new SelectList(db.Closets, "Id", "Name", patchPanel.ClosetId);
            return View(patchPanel);
        }

        // GET: PatchPanels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatchPanel patchPanel = db.PatchPanels.Find(id);
            if (patchPanel == null)
            {
                return HttpNotFound();
            }
            return View(patchPanel);
        }

        // POST: PatchPanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatchPanel patchPanel = db.PatchPanels.Find(id);
            db.PatchPanels.Remove(patchPanel);
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
