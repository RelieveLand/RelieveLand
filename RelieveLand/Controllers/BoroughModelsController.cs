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
            if (admins.Contains(User.Identity.Name.ToString()))
            {
                return View(db.BoroughModels.ToList());
            }
            else
            {
                return HttpNotFound();
            }
        }



        public ViewResult Details(int? id, string sortOrder, /*string searchEstName, string searchHoursOfOper,*/ bool? searchSingleStall, /*string searchHandDryer,*/ bool? searchChangingStation, bool? searchPurchaseNeeded, bool? searchHandicapStall, bool? searchHygieneProducts, bool? searchFamilyRestroom,/* float? searchOverallAvg,*/ string searchString, int? page)
        {
            var boroughModels = db.BoroughModels.Find(id);

            if (searchString == null)
            {
                page = 1;
            }
            else
            {
                searchString = ViewBag.SearchSingleStall+ViewBag.SearchChangingStation+ViewBag.SearchPurchaseNeeded+ViewBag.SearchHandicapStall+ViewBag.SearchHygieneProducts+ViewBag.SearchFamilyRestroom;
            }

            ViewBag.CurrentFilter = searchString;

            //var viewModel = new BoroughEstablishmentViewModel
            //{
            //    BoroughModel = boroughModels,

            //    EstablishmentModel = (from e in db.EstablishmentModels
            //                          where e.BoroughPrimary == boroughModels.BoroughName || e.BoroughSecondary == boroughModels.BoroughName
            //                          orderby e.OverallAvg descending
            //                          select e)
            //};

            var results = from s in db.EstablishmentModels
                          where s.BoroughPrimary == boroughModels.BoroughName || s.BoroughSecondary == boroughModels.BoroughName
                          select s;

            if (/*searchEstName != null || searchHoursOfOper != null ||*/ searchSingleStall == true || /*searchHandDryer != null ||*/ searchChangingStation == true || searchPurchaseNeeded ==true || searchHandicapStall ==true || searchHygieneProducts ==true || searchFamilyRestroom ==true /*|| searchOverallAvg != null*/)
            {
                page = 1;
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
                results = results.Where(s => s.SingleStall == searchSingleStall);
            }
            //if (!String.IsNullOrEmpty(searchHandDryer))
            //{
            //    results = results.Where(s => s.HandDryer.ToUpper().Contains(searchHandDryer.ToUpper()));
            //}
            if (searchChangingStation == true)
            {
                results = results.Where(x => x.ChangingStation == searchChangingStation);
            }
            if (searchPurchaseNeeded == true)
            {
                results = results.Where(x => x.PurchaseNeeded == searchPurchaseNeeded);
            }
            if (searchHandicapStall == true)
            {
                results = results.Where(x => x.SingleStall == searchHandicapStall);
            }
            if (searchHygieneProducts == true)
            {
                results = results.Where(x => x.HygieneProducts == searchHygieneProducts);
            }
            if (searchFamilyRestroom == true)
            {
                results = results.Where(x => x.FamilyRestroom == searchFamilyRestroom);
            }
            //if (searchOverallAvg.HasValue)
            //{
            //    results = results.Where(x => x.SingleStall == searchSingleStall);
            //}
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //var establishmentModel = db.EstablishmentModels.OrderBy(s => s.EstName).ToPagedList(pageNumber,pageSize);
            return View(results.OrderByDescending(s => s.OverallAvg).ToPagedList(pageNumber, pageSize));
            //return View(establishmentModel);
        }




        // GET: BoroughModels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BoroughModels boroughModels = db.BoroughModels.Find(id);
        //    if (boroughModels == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var viewModel = new BoroughEstablishmentViewModel
        //    {
        //        BoroughModel = boroughModels,

        //        EstablishmentModel = (from e in db.EstablishmentModels
        //                       where e.BoroughPrimary == boroughModels.BoroughName || e.BoroughSecondary == boroughModels.BoroughName
        //                       orderby e.OverallAvg descending
        //                       select e)
        //    };


        //    return View(viewModel);
        //}

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
