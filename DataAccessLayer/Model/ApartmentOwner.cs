using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ApartmentOwner
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
    }
}
