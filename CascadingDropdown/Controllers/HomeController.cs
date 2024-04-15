using CascadingDropdown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropdown.Controllers
{
    public class HomeController : Controller
    {
        CascadingDropdownEntities db = new CascadingDropdownEntities();
        public ActionResult Index()
        {
            List<Country> countries = db.Countries.ToList();
            ViewBag.Country = new SelectList(countries, "CountryId", "CountryName");
            return View();
        }

        public JsonResult GetStateList(int CountryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<State> StateList = db.States.Where(x => x.CountryId == CountryId).ToList();

            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}