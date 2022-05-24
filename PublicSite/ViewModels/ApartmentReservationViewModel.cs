﻿using PublicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicSite.ViewModels
{
    public class ApartmentReservationViewModel
    {
        public Apartment Apartment{ get; set; }
        public Reservation Reservation { get; set; }
        public UserReview Review { get; set; }
        public List<DataAccessLayer.Model.Tag> ApartmentTags { get; set; }
        public List<DataAccessLayer.Model.ApartmentPicture> ApartmentPictures { get; set; }
    }
}