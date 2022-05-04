using PublicSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicSite.Models;
using DataAccessLayer.Dal;

namespace PublicSite.Controllers
{
    public class HomeController : Controller
    {

        // Home/Index
        public ActionResult Index()
        {
            List<Apartment> listOfApartments = new List<Apartment>();
            RepoFactory.GetRepo().GetApartments()
                .ToList().ForEach(element => listOfApartments.Add(new Apartment
                {
                    Name = element.Name,
                    CityName = element.CityName,
                    BeachDistance = element.BeachDistance,
                    RoomCount = element.TotalRooms,
                    MaxAdults = element.MaxAdults,
                    MaxChildren = element.MaxChildren,
                    Price = element.Price,
                }));
            var viewModelStuff = new ApartmentViewModel
            {
                Apartments = listOfApartments,
            };
            return View(viewModelStuff);
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