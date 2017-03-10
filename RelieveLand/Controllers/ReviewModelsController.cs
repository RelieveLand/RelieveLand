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
    [Authorize]
    public class ReviewModelsController : Controller
    {
        private RelieveLandContext db = new RelieveLandContext();

        // GET: ReviewModels
        public ActionResult Index()
        {
            var reviewModels = db.ReviewModels.Include(r => r.EstablishmentModels);
            return View(reviewModels.ToList());
        }

        // GET: ReviewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModels reviewModels = db.ReviewModels.Find(id);
            if (reviewModels == null)
            {
                return HttpNotFound();
            }
            return View(reviewModels);
        }

        // GET: ReviewModels/Create
        public ActionResult Create()
        {
            ViewBag.EstID = new SelectList(db.EstablishmentModels, "EstID", "EstName");
            return View();
        }

        // POST: ReviewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,ReviewTime,OverallRating,OdorRating,AppearRating,UserName,UserComments,EstID")] ReviewModels reviewModels)
        {
            if (ModelState.IsValid)
            {
                db.ReviewModels.Add(reviewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstID = new SelectList(db.EstablishmentModels, "EstID", "EstName", reviewModels.EstID);
            return View(reviewModels);
        }

        // GET: ReviewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (db.ReviewModels.Find(id).UserName != User.Identity.Name.ToString())
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModels reviewModels = db.ReviewModels.Find(id);
            if (reviewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstID = new SelectList(db.EstablishmentModels, "EstID", "EstName", reviewModels.EstID);
            return View(reviewModels);
        }

        // POST: ReviewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,ReviewTime,OverallRating,OdorRating,AppearRating,UserName,UserComments,EstID")] ReviewModels reviewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstID = new SelectList(db.EstablishmentModels, "EstID", "EstName", reviewModels.EstID);
            return View(reviewModels);
        }

        // GET: ReviewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (db.ReviewModels.Find(id).UserName != User.Identity.Name.ToString())
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModels reviewModels = db.ReviewModels.Find(id);
            if (reviewModels == null)
            {
                return HttpNotFound();
            }
            return View(reviewModels);
        }

        // POST: ReviewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewModels reviewModels = db.ReviewModels.Find(id);
            db.ReviewModels.Remove(reviewModels);
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
