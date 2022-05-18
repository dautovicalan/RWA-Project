using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace PublicSite.Models
{

    public enum SortType
    {
        Id,
        Price
    }
    public class ApartmentFilter
    {
        private const char DEL = '|';

        [Display(Name = "Room count")]
        [Required(ErrorMessage = "Missing data")]
        public int RoomCount { get; set; }
        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Max adults")]
        public int MaxAdults { get; set; }
        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Max children")]
        public int MaxChildren{ get; set; }
        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "City")]
        public string CityName { get; set; }
        public SortType SortType { get; set; }

        public string PrepareForCookie()
        {
            return $"{RoomCount}{DEL}{MaxAdults}{DEL}{MaxChildren}{DEL}{CityName}{DEL}{SortType}";
        }

        public static ApartmentFilter ReadFromCookie(string cookieParams)
        {
            if (String.IsNullOrEmpty(cookieParams))
            {
                return null;
            }
            string[] testing = cookieParams.Split(DEL);
            return new ApartmentFilter
            {
                RoomCount = int.Parse(testing[0]),
                MaxAdults = int.Parse(testing[1]),
                MaxChildren = int.Parse(testing[2]),
                CityName = testing[3],
            };
        }
    }
}