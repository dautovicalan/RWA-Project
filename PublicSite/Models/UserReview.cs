using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicSite.Models
{
    public class UserReview
    {
        public string ApartmentId { get; set; }
        public string Details { get; set; }
        public int StarCount { get; set; }
    }
}