using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ApartmentStatus
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        internal static ApartmentStatus ParseFromReader(SqlDataReader reader)
        {
            return new ApartmentStatus
            {
                Id = reader.GetInt32(0),
                NameEng = reader.GetString(1),
            };
        }
    }
}
