using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelieveLand.Models;

namespace RelieveLand.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "RelieveLand was created by Software Development Boot Camp Students at We Can Code IT in Cleveland, Ohio to help you find a place for relief in CLE. A snippet about each of us follows below.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Any issues, bugs, errors, or incorrect details we have about a restroom? Please let us know.";

            return View();
        }
    }
}