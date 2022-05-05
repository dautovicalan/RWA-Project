using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicSite.Models
{
    public class Reservation
    {
        [Required(ErrorMessage = "Missing data")]
        [Display(Name ="Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Surname")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Missing data")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Missing data")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Max adults")]
        public int? MaxAdults{ get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Max children")]
        public int? MaxChildren { get; set; }

        [Required(ErrorMessage = "Missing data")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Missing data")]
        public DateTime To { get; set; }
    }
}