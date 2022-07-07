using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicSite.Models
{
    public class Reservation
    {
        public int ApartmentId { get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "Phone", ResourceType = typeof(Resource))]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "UserAddress", ResourceType = typeof(Resource))]
        public string UserAddress { get; set; }     

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "MaxAdults", ResourceType = typeof(Resource))]
        public int? MaxAdults{ get; set; }

        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "MaxChildren", ResourceType = typeof(Resource))]
        public int? MaxChildren { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "From", ResourceType = typeof(Resource))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime From { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Missing data")]
        [Display(Name = "To", ResourceType = typeof(Resource))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime To { get; set; }
    }
}