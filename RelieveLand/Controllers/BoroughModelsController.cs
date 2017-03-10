using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RelieveLand.Models;

namespace RelieveLand.Controllers
{
    public class BoroughModelsController : Controller
    {
        private RelieveLandContext db = new RelieveLandContext();

        // GET: BoroughModels
        public ActionResult Index()
        {
            return View(db.BoroughModels.ToList());
        }

        // GET: BoroughModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoroughModels boroughModels = db.BoroughModels.Find(id);
            if (boroughModels == null)
            {
                return HttpNotFound();
            }
            return View(boroughModels);
        }

        // GET: BoroughModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoroughModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoroughID,BoroughName")] BoroughModels boroughModels)
        {
            if (ModelState.IsValid)
            {
                db.BoroughModels.Add(boroughModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boroughModels);
        }

        // GET: BoroughModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoroughModels boroughModels = db.BoroughModels.Find(id);
            if (boroughModels == null)
            {
                return HttpNotFound();
            }
            return View(boroughModels);
        }

        // POST: BoroughModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoroughID,BoroughName")] BoroughModels boroughModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boroughModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boroughModels);
        }

        // GET: BoroughModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoroughModels boroughModels = db.BoroughModels.Find(id);
            if (boroughModels == null)
            {
                return HttpNotFound();
            }
            return View(boroughModels);
        }

        // POST: BoroughModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoroughModels boroughModels = db.BoroughModels.Find(id);
            db.BoroughModels.Remove(boroughModels);
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
