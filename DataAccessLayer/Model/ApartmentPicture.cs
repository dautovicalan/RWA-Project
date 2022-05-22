using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ApartmentPicture
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int ApartmentId { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public bool IsRepresentative { get; set; }

        public static ApartmentPicture ParseFromReader(SqlDataReader row)
        {
            return new ApartmentPicture
            {
                Id = Convert.ToInt32(row["ID"]),
                Name = Convert.ToString(row["Name"]),
                ImageData = Encoding.ASCII.GetBytes(Convert.ToString(row["ImageData"])),
                IsRepresentative = Convert.ToBoolean(row["IsRepresentative"])
            };
        }
    }
}
