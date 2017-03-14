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
    public class EstablishmentModelsController : Controller
    {
        private RelieveLandContext db = new RelieveLandContext();

        // GET: EstablishmentModels
        public ActionResult Index()
        {
            return View(db.EstablishmentModels.ToList());
        }

        // GET: EstablishmentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentModels establishmentModels = db.EstablishmentModels.Find(id);
            if (establishmentModels == null)
            {
                return HttpNotFound();
            }


            var viewModel = new ReviewEstablishmentViewModel
            {
                //We can reuse the comment form from a couple of lines above
                EstablishmentModel = establishmentModels,
                //We don't want to pull back all the procedures, just the one with the same priority as our comment
                ReviewModel = (from r in db.ReviewModels
                             where r.EstID == establishmentModels.EstID
                             select r)
            };



            return View(viewModel);
        }

        // GET: EstablishmentModels/Create
        public ActionResult Create()
        {
            List<string> admins = new List<string>() { "sam.saunders116@yahoo.com", "humbleandrew13@gmail.com", "jcarg108@gmail.com",
                "lavellebrown@yahoo.com", "kj5thguitar@gmail.com" };
            if (admins.Contains(User.Identity.Name.ToString()))
            {
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: EstablishmentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstID,EstName,EstImage,EstAddress,ZipCode,BoroughPrimary,BoroughSecondary,HoursOfOper,SingleStall,HandDryer,ChangingStation,PurchaseNeeded,HandicapStall,HygieneProducts,FamilyRestroom,Extras,OverallAvg,OdorAvg,AppearAvg")] EstablishmentModels establishmentModels)
        {
            if (ModelState.IsValid)
            {
                db.EstablishmentModels.Add(establishmentModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(establishmentModels);
        }

        // GET: EstablishmentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentModels establishmentModels = db.EstablishmentModels.Find(id);
            if (establishmentModels == null)
            {
                return HttpNotFound();
            }

            List<string> admins = new List<string>() { "sam.saunders116@yahoo.com", "humbleandrew13@gmail.com", "jcarg108@gmail.com",
                "lavellebrown@yahoo.com", "kj5thguitar@gmail.com" };
            if (admins.Contains(User.Identity.Name.ToString()))
            {
                return View(establishmentModels);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: EstablishmentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstID,EstName,EstImage,EstAddress,ZipCode,BoroughPrimary,BoroughSecondary,HoursOfOper,SingleStall,HandDryer,ChangingStation,PurchaseNeeded,HandicapStall,HygieneProducts,FamilyRestroom,Extras,OverallAvg,OdorAvg,AppearAvg")] EstablishmentModels establishmentModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establishmentModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(establishmentModels);
        }

        // GET: EstablishmentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentModels establishmentModels = db.EstablishmentModels.Find(id);
            if (establishmentModels == null)
            {
                return HttpNotFound();
            }

            List<string> admins = new List<string>() { "sam.saunders116@yahoo.com", "humbleandrew13@gmail.com", "jcarg108@gmail.com",
                "lavellebrown@yahoo.com", "kj5thguitar@gmail.com" };
            if (admins.Contains(User.Identity.Name.ToString()))
            {
                return View(establishmentModels);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: EstablishmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstablishmentModels establishmentModels = db.EstablishmentModels.Find(id);
            db.EstablishmentModels.Remove(establishmentModels);
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
