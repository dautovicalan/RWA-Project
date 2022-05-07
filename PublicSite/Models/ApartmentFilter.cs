using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicSite.Models
{
    public class ApartmentFilter
    {
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
    }
}