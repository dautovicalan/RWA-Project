using PublicSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicSite.Models;
using DataAccessLayer.Dal;
using Newtonsoft.Json;
using System.Threading;
using System.Globalization;
using System.Configuration;
using CaptchaMvc.HtmlHelpers;
using Microsoft.AspNet.Identity;

namespace PublicSite.Controllers
{
    public class HomeController : Controller
    {
        private IRepo _repo;

        public HomeController()
        {
            _repo = RepoFactory.GetRepo();
        }

        // Home/Index
        public ActionResult Index()
        {
            try
            {
                List<Apartment> listOfApartments = new List<Apartment>();
                List<DataAccessLayer.Model.City> cityList = _repo.GetCitys().ToList();
                _repo.GetApartments()
                    .ToList().ForEach(element =>
                    {
                        listOfApartments.Add(new Apartment
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
                            MainApartmentImage = new ImageModel { ImageData = element.MainPicture.ImageData}
                        });
                    });
                ApartmentFilter myFilters = ApartmentFilter.ReadFromCookie(HttpContext.Request.Cookies["sortingFilterOptions"]?.Value);

                if (myFilters != null)
                {
                    return View(new ApartmentViewModel
                    {
                        ApartmentFilter = myFilters,
                        Cities = cityList,
                        Apartments = FilterApartments(myFilters)
                    });
                }

                var viewModelStuff = new ApartmentViewModel
                {
                    Apartments = listOfApartments,
                    Cities = cityList,
                    ApartmentFilter = myFilters
                };
                return View(viewModelStuff);
            }
            catch (Exception e)
            {
                return View("Error", new { message = e.Message });   
            }
        }

        [HttpPost]
        public ActionResult GetFilteredApartments(ApartmentFilter filters)
        {
            if (filters == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Response.Cookies.Add(new HttpCookie("sortingFilterOptions", filters.PrepareForCookie()));
            
            List<Apartment> listOfApartments  = FilterApartments(filters);

            if (listOfApartments.Count == 0)
            {
                return PartialView("_AllApartments", new ApartmentViewModel
                {
                    ApartmentFilter = filters,
                    Apartments = new List<Apartment>()
                });
            }
            ApartmentViewModel apartmentViewModel = new ApartmentViewModel
            {
                Apartments = listOfApartments,
                ApartmentFilter = filters
            };            
            return PartialView("_AllApartments", apartmentViewModel);
        }

        private List<Apartment> FilterApartments(ApartmentFilter filters)
        {
            List<DataAccessLayer.Model.Apartment> apartmani = _repo.GetApartments().ToList();

            List<DataAccessLayer.Model.Apartment> allDataLayerApartments = apartmani.FindAll(x => x.TotalRooms >= filters.RoomCount && x.MaxAdults >= filters.MaxAdults
                                                        && x.MaxChildren >= filters.MaxChildren && x.CityName == filters.CityName);

            List<Apartment> listOfApartments = new List<Apartment>();
            allDataLayerApartments.ForEach(x => listOfApartments.Add(new Apartment
            {
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

            listOfApartments.Sort((x, y) => -x.Price.CompareTo(y.Price));

            return listOfApartments;
        }

        // Home/ApartmentInformation/id
        public ActionResult ApartmentInformation(int? id)
        {
            try
            {
                if (id == null) { return RedirectToAction("Index", "Home"); }

                var selectedApartment = _repo.GetApartmentById(id.Value);
                Session["selectedApartment"] = selectedApartment;

                return View(PrepareApartmetnReservatioViewModel(selectedApartment));
            }
            catch (Exception e)
            {                
                return View("ApartmentNotFound", id.Value);                
            }
        }

        private ApartmentReservationViewModel PrepareApartmetnReservatioViewModel(DataAccessLayer.Model.Apartment selectedApartment)
        {
            Reservation reska = (Reservation)(Session["reservation"] != null ? Session["reservation"] : new Reservation());
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
                MainApartmentImage = new ImageModel { ImageData = selectedApartment.MainPicture.ImageData },
            };

            List<DataAccessLayer.Model.Tag> apartTags = _repo.GetApartmentTags(selectedApartment.Id).ToList();
            List<DataAccessLayer.Model.ApartmentPicture> apartPicture = _repo.GetAllApartmentPictures(selectedApartment.Id).ToList();            

            return new ApartmentReservationViewModel
            {
                Apartment = apartko,
                Reservation = reska,
                ApartmentTags = apartTags,
                ApartmentPictures = apartPicture
            };
        }

        [HttpPost]
        public ActionResult ApartmentInformation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                Session["reservationModel"] = reservation;
                return View("ApartmentInformation", PrepareApartmetnReservatioViewModel((DataAccessLayer.Model.Apartment)Session["selectedApartment"]));
            }
            if (!this.IsCaptchaValid(""))
            {
                ViewBag.ErrorMessage = "Captcha is not valid";
                return View("ApartmentInformation", PrepareApartmetnReservatioViewModel((DataAccessLayer.Model.Apartment)Session["selectedApartment"]));
            }
            if (User.Identity.IsAuthenticated)
            {
                _repo.CreateApartmentReservationRegisteredUser(new DataAccessLayer.Model.ApartmentReservation
                {
                    CreatedAt = DateTime.Now,
                    ApartmentId = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString()),
                    Details = reservation.From.ToString(),
                    UserId = User.Identity.GetUserId(),
                });
            }
            else
            {
                _repo.CreateApartmentReservationNonRegisteredUser(
                new DataAccessLayer.Model.ApartmentReservation
                {
                    CreatedAt = DateTime.Now,
                    ApartmentId = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString()),
                    Details = reservation.From.ToString(),
                    UserName = reservation.UserName,
                    UserEmail = reservation.Email,
                    UserPhone = reservation.Phone,
                    UserAddress = reservation.UserAddress,
                });
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SubmitApartmentReview(UserReview userReview)
        {
            _repo.InsertUserReview(new DataAccessLayer.Model.ApartmentReview
            {
                UserId = User.Identity.GetUserId(),
                ApartmentId = int.Parse(userReview.ApartmentId),
                Details = userReview.Details,
                Stars = userReview.StarCount
            });
            return RedirectToAction("Index", "Home");
        }

        // Home/Contact
        public ActionResult Contact() => View();       
    }
}