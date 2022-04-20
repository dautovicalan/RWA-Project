using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ApartmentOwner
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }

        internal static ApartmentOwner ParseFromReader(SqlDataReader reader)
        {
            return new ApartmentOwner
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
            };
        }
    }
}
