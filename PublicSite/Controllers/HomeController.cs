using PublicSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicSite.Models;
using DataAccessLayer.Dal;
using Newtonsoft.Json;
using CaptchaMvc.HtmlHelpers;

namespace PublicSite.Controllers
{
    public class HomeController : Controller
    {

        // Home/Index
        public ActionResult Index()
        {
            List<Apartment> listOfApartments = new List<Apartment>();
            List<DataAccessLayer.Model.City> cityList = RepoFactory.GetRepo().GetCitys().ToList();
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
                    ApartmentStars = element.ApartmentStars,
                }));
            var viewModelStuff = new ApartmentViewModel
            {
                Apartments = listOfApartments,
                Cities = cityList,
            };
            return View(viewModelStuff);
        }

        [HttpPost]
        public PartialViewResult GetFilteredApartments(ApartmentFilter filters)
        {

            List<DataAccessLayer.Model.Apartment> apartmani = RepoFactory.GetRepo().GetApartments().ToList();

            List<DataAccessLayer.Model.Apartment> all = apartmani.FindAll(x => x.TotalRooms >= filters.RoomCount && x.MaxAdults >= filters.MaxAdults
                                                        && x.MaxChildren >= filters.MaxChildren && x.CityName == filters.CityName);


            List<Apartment> myAparts = new List<Apartment>();
            all.ForEach(x => myAparts.Add(new Apartment { 
                Id = x.Id, 
                MaxChildren = x.MaxChildren, 
                Name = x.Name, 
                CityName = x.CityName, 
                MaxAdults = x.MaxAdults,
                RoomCount = x.TotalRooms,
                OwnerName = x.OwnerName,
                Price = x.Price,
                BeachDistance = x.BeachDistance,                
            }));

            myAparts.Sort((x, y) => -x.Price.CompareTo(y.Price));

            ApartmentViewModel hello = new ApartmentViewModel
            {
                Apartments = myAparts,
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
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                return RedirectToAction("Index", "Home");
            }

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

        [HttpPost]
        public ActionResult SubmitApartmentReview(UserReview userReview)
        {
            int test = userReview.StarCount;
            //call sp in database
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