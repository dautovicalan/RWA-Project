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
                    Id = element.Id,
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

        // Home/ApartmentInformation/id
        public ActionResult ApartmentInformation(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            
            var selectedApartment = RepoFactory.GetRepo().GetApartmentById(id.Value);

            return View(new Apartment { Id = selectedApartment.Id, Name = selectedApartment.Name, CityName = selectedApartment.CityName});
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