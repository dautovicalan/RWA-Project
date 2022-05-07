using PublicSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicSite.Models;
using DataAccessLayer.Dal;
using Newtonsoft.Json;

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
                    OwnerName = element.OwnerName,
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

        [HttpPost]
        public PartialViewResult GetFilteredApartments(ApartmentFilter filters)
        {
            List<Apartment> testing = new List<Apartment>();
            testing.Add(new Apartment { Name = "Pero" });
            testing.Add(new Apartment { Name = "Mero" });
            testing.Add(new Apartment { Name = "Kero" });


            ApartmentViewModel hello = new ApartmentViewModel
            {
                Apartments = testing,
                ApartmentFilter = filters
            };


            return PartialView("_AllApartments", hello);
        }

        // Home/ApartmentInformation/id
        public ActionResult ApartmentInformation(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            
            var selectedApartment = RepoFactory.GetRepo().GetApartmentById(id.Value);

            Reservation reska = new Reservation();
            Apartment apartko = new Apartment
            {
                Id = selectedApartment.Id,
                Name = selectedApartment.Name,
                CityName = selectedApartment.CityName,
                OwnerName = selectedApartment.OwnerName,
                BeachDistance = selectedApartment.BeachDistance,
                RoomCount = selectedApartment.TotalRooms,
                MaxChildren = selectedApartment.MaxChildren,
                MaxAdults = selectedApartment.MaxAdults,
                Price = selectedApartment.Price,
            };

            return View(new ApartmentReservationViewModel { Apartment = apartko, Reservation = reska});
        }

        [HttpPost]
        public ActionResult ApartmentInformation(Reservation reservation)
        {
            string userName = reservation.UserName;
            string userEmail = reservation.Email;
            string userPhone = reservation.Phone;
            string userAddress = reservation.UserAddress;

            RepoFactory.GetRepo().CreateApartmentReservationNonRegisteredUser(
                new DataAccessLayer.Model.ApartmentReservation
                {
                    Guid = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    ApartmentId = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString()),
                    Details = reservation.From.ToString(),
                    UserName = userName,
                    UserEmail = userEmail,
                    UserPhone = userPhone,
                    UserAddress = userAddress,
                });            
            return RedirectToAction("Index", "Home");
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