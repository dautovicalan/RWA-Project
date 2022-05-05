using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicSite.Models
{
    public class Apartment
    {
        // MVC Model
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public int BeachDistance { get; set; }
        public int RoomCount { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public double Price { get; set; }
    }
}