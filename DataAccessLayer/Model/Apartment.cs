﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Apartment
    {
        public string Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int OwnerId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string NamgeEng { get; set; }
        public double Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }

    }
}
