using PublicSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicSite.Controllers
{
    public class HomeController : Controller
    {

        // Home/Index
        public ActionResult Index()
        {
            var testData = new ApartmentViewModel
            {
                Apartments = new List<Models.Apartment>
                {
                    new Models.Apartment { Name = "Hello"},
                    new Models.Apartment { Name = "Alan"},
                    new Models.Apartment { Name = "Pero"},
                    new Models.Apartment { Name = "Mero"},
                }
            };
            return View(testData);
        }

        // Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";            

            return View();
        }
        // Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}