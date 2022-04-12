using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class TaggedApartment
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public int ApartmentId { get; set; }
        public int TagId { get; set; }
    }
}
