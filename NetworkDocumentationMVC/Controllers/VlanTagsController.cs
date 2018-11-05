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
    public class VlanTagsController : Controller
    {
        private NetworkDataEntities db = new NetworkDataEntities();

        // GET: VlanTags
        public ActionResult Index()
        {
            return View(db.VlanTags.ToList());
        }

        // GET: VlanTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VlanTag vlanTag = db.VlanTags.Find(id);
            if (vlanTag == null)
            {
                return HttpNotFound();
            }
            return View(vlanTag);
        }

        // GET: VlanTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VlanTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tagged")] VlanTag vlanTag)
        {
            if (ModelState.IsValid)
            {
                db.VlanTags.Add(vlanTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vlanTag);
        }

        // GET: VlanTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VlanTag vlanTag = db.VlanTags.Find(id);
            if (vlanTag == null)
            {
                return HttpNotFound();
            }
            return View(vlanTag);
        }

        // POST: VlanTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tagged")] VlanTag vlanTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vlanTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vlanTag);
        }

        // GET: VlanTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VlanTag vlanTag = db.VlanTags.Find(id);
            if (vlanTag == null)
            {
                return HttpNotFound();
            }
            return View(vlanTag);
        }

        // POST: VlanTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VlanTag vlanTag = db.VlanTags.Find(id);
            db.VlanTags.Remove(vlanTag);
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
