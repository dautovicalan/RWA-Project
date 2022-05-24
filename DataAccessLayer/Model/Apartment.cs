using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Apartment
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public double Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int PictureCount { get; set; }
        public int BeachDistance { get; set; }
        public string StatusName { get; set; }
        public int ApartmentStars { get; set; }
        public ApartmentPicture MainPicture { get; set; }

        public static Apartment ParseFromReader(SqlDataReader row)
        {
            return new Apartment
            {
                Id = Convert.ToInt32(row["Id"]),
                CityName = Convert.ToString(row["CityName"]),
                Name = Convert.ToString(row["Name"]),
                PictureCount = Convert.ToInt32(row["PictureNumber"]),
                Price = Convert.ToDouble(row["Price"]),
                MaxAdults = Convert.ToInt32(row["MaxAdults"]),
                MaxChildren = Convert.ToInt32(row["MaxChildren"]),
                TotalRooms = Convert.ToInt32(row["TotalRooms"]),
                BeachDistance = Convert.ToInt32(row["BeachDistance"]),
                StatusName = Convert.ToString(row["NameEng"]),
                OwnerName = Convert.ToString(row["OwnerName"]),
                ApartmentStars = Convert.IsDBNull(row[nameof(ApartmentStars)]) ? 0 : Convert.ToInt32(row[nameof(ApartmentStars)]),
                MainPicture = new ApartmentPicture { ImageData = (byte[])row["ImageData"]}


            };
        }

    }
}
