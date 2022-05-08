using PublicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicSite.ViewModels
{
    public class ApartmentViewModel
    {
        public List<Apartment> Apartments { get; set; }
        public ApartmentFilter ApartmentFilter { get; set; }
        public List<DataAccessLayer.Model.City> Cities { get; set; }
    }
}