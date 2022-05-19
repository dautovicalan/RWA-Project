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
using System.Threading;
using System.Globalization;
using System.Configuration;

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
            ApartmentFilter myFilters = ApartmentFilter.ReadFromCookie(HttpContext.Request.Cookies["sortingFilterOptions"]?.Value);
            var viewModelStuff = new ApartmentViewModel
            {
                Apartments = listOfApartments,
                Cities = cityList,
                ApartmentFilter = myFilters
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

            HttpCookie filterSortCookie = new HttpCookie("sortingFilterOptions", filters.PrepareForCookie());
            HttpContext.Response.Cookies.Add(filterSortCookie);
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

            List<DataAccessLayer.Model.Tag> apartTags = RepoFactory.GetRepo().GetApartmentTags(id.Value).ToList();

            return View(new ApartmentReservationViewModel 
            { 
                Apartment = apartko, 
                Reservation = reska, 
                ApartmentTags = apartTags
            });
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
            RepoFactory.GetRepo().InsertUserReview(new DataAccessLayer.Model.ApartmentReview
            {
                UserId = ((DataAccessLayer.Model.AspNetUser)Session["user"]).Id,
                ApartmentId = int.Parse(userReview.ApartmentId),
                Details = userReview.Details,
                Stars = userReview.StarCount
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