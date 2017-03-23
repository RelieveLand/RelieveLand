using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RelieveLand.Models;
using PagedList;

namespace RelieveLand.Controllers
{
    public class BoroughModelsController : Controller
    {
        private RelieveLandContext db = new RelieveLandContext();

        // GET: BoroughModels
        public ActionResult Index()
        {
            List<string> admins = new List<string>() { "sam.saunders116@yahoo.com", "humbleandrew13@gmail.com", "jcarg108@gmail.com",
                "lavellebrown@yahoo.com", "kj5thguitar@gmail.com" };
            if (admins.Contains(User.Identity.Name.ToString().ToLower()))
            {
                return View(db.BoroughModels.ToList());
            }
            else
            {
                return HttpNotFound();
            }
        }



        public ViewResult Details(int? id, string sortOrder, string currentFilter,/*string searchEstName, string searchHoursOfOper,*/ bool? searchSingleStall, /*string searchHandDryer,*/ bool? searchChangingStation, bool? searchPurchaseNeeded, bool? searchHandicapStall, bool? searchHygieneProducts, bool? searchFamilyRestroom,/* float? searchOverallAvg,*/ string searchString, int? page)
        {
            var boroughModels = db.BoroughModels.Find(id);

            if (searchString != null)
            {
                page = (page ?? 1);
            }
            else
            {
                searchString = currentFilter;
            }

            var results = from s in db.EstablishmentModels
                          where s.BoroughPrimary == boroughModels.BoroughName || s.BoroughSecondary == boroughModels.BoroughName
                          select s;

            if (/*searchEstName != null || searchHoursOfOper != null ||*/ searchSingleStall == true || /*searchHandDryer != null ||*/ searchChangingStation == true || searchPurchaseNeeded == true || searchHandicapStall == true || searchHygieneProducts == true || searchFamilyRestroom == true /*|| searchOverallAvg != null*/)
            {
                page = (page ?? 1);
            }
            else
            {
                searchChangingStation = false;
                searchFamilyRestroom = false;
                searchHandicapStall = false;
                searchHygieneProducts = false;
                searchPurchaseNeeded = false;
                searchSingleStall = false;
            }
            //if (!String.IsNullOrEmpty(searchEstName))
            //{
            //    results = results.Where(s => s.EstName.ToUpper().Contains(searchEstName.ToUpper()));
            //}
            //if (!String.IsNullOrEmpty(searchHoursOfOper))
            //{
            //    results = results.Where(s => s.HoursOfOper.ToUpper().Contains(searchHoursOfOper.ToUpper()));
            //}
            if (searchSingleStall == true)
            {
                searchString = "&searchSingleStall=true&";
                results = results.Where(s => s.SingleStall == searchSingleStall);
            }
            //if (!String.IsNullOrEmpty(searchHandDryer))
            //{
            //    results = results.Where(s => s.HandDryer.ToUpper().Contains(searchHandDryer.ToUpper()));
            //}
            if (searchChangingStation == true)
            {
                searchString += "&searchChangingStation=true&";
                results = results.Where(s => s.ChangingStation == searchChangingStation);
            }
            if (searchPurchaseNeeded == true)
            {
                searchString += "&searchPurchaseNeeded=true&";
                results = results.Where(s => s.PurchaseNeeded == searchPurchaseNeeded);
            }
            if (searchHandicapStall == true)
            {
                searchString += "&searchHandicapStall=true&";
                results = results.Where(s => s.SingleStall == searchHandicapStall);
            }
            if (searchHygieneProducts == true)
            {
                searchString += "&searchHygieneProducts=true&";
                results = results.Where(s => s.HygieneProducts == searchHygieneProducts);
            }
            if (searchFamilyRestroom == true)
            {
                searchString += "&searchFamilyRestroom=true&";
                results = results.Where(s => s.FamilyRestroom == searchFamilyRestroom);
            }
            //if (searchOverallAvg.HasValue)
            //{
            //    results = results.Where(x => x.SingleStall == searchSingleStall);
            //}
            //if (searchString != null)

            ViewBag.CurrentFilter = searchString;

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(results.OrderByDescending(s => s.OverallAvg).ToPagedList(pageNumber, pageSize));
        }

        // GET: BoroughModels/Create
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
                return HttpNotFound();
            }
            BoroughModels boroughModels = db.BoroughModels.Find(id);
            if (boroughModels == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
