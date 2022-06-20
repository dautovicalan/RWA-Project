using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Dal
{
    public class DatabaseRepo : IRepo
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ApartmentDatabase"].ConnectionString;
        //private string connectionString = "Data Source=DESKTOP-SUOTGOE\\SQLEXPRESS;Initial Catalog=RwaApartmani;Integrated Security=True";


        private SqlConnection connection;
        private SqlCommand command;

        public int CreateApartment(Apartment apartment)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("CreateApartment", connection);
                command.Parameters.AddWithValue("guid", apartment.Guid);
                command.Parameters.AddWithValue("createdAt", apartment.CreatedAt);
                command.Parameters.AddWithValue("ownerId", apartment.OwnerId);
                command.Parameters.AddWithValue("typeId", apartment.TypeId);
                command.Parameters.AddWithValue("statusId", apartment.StatusId);
                command.Parameters.AddWithValue("cityId", apartment.CityId);
                command.Parameters.AddWithValue("address", apartment.Address);
                command.Parameters.AddWithValue("name", apartment.Name);
                command.Parameters.AddWithValue("nameEng", apartment.NameEng);
                command.Parameters.AddWithValue("price", apartment.Price);
                command.Parameters.AddWithValue("maxAdults", apartment.MaxAdults);
                command.Parameters.AddWithValue("maxChildren", apartment.MaxChildren);
                command.Parameters.AddWithValue("totalRooms", apartment.TotalRooms);
                command.Parameters.AddWithValue("beachDistance", apartment.BeachDistance);
                command.Parameters.Add("createdApartment", System.Data.SqlDbType.Int);
                command.Parameters["createdApartment"].Direction = System.Data.ParameterDirection.Output;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                return Convert.ToInt32(command.Parameters["createdApartment"].Value);
            }
        }

        public void CreateTag(Tag tag)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("CreateTag", connection);
                command.Parameters.AddWithValue("guid", tag.Guid);
                command.Parameters.AddWithValue("createdAt", tag.CreatedAt);
                command.Parameters.AddWithValue("typeId", tag.TypeId);
                command.Parameters.AddWithValue("name", tag.Name);
                command.Parameters.AddWithValue("nameEng", tag.NameEng);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public void SoftDeleteApartmentById(int aparmentId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("SoftDeleteApartmentById", connection);
                command.Parameters.AddWithValue("id", aparmentId);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTagById(int tagId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(DeleteTagById), connection);
                command.Parameters.AddWithValue("id", tagId);
                command.CommandType=System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public Apartment GetApartmentById(int apartmentId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetApartmentById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", apartmentId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return Apartment.ParseFromReader(reader);
                    }
                    throw new Exception("No such apartment");
                }
            }
        }

        public IList<ApartmentOwner> GetApartmentOwners()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetApartmentOwners", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<ApartmentOwner> list = new List<ApartmentOwner>();
                    while (reader.Read())
                    {
                        list.Add(ApartmentOwner.ParseFromReader(reader));
                    }
                    return list;
                }
            }
        }

        public IList<Apartment> GetApartments()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetApartments", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<Apartment> list = new List<Apartment>();
                    while (reader.Read())
                    {
                        list.Add(Apartment.ParseFromReader(reader));
                    }
                    return list;
                }
            }
        }

        public IList<ApartmentStatus> GetApartmentStatuses()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetApartmentStatuses", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<ApartmentStatus> apartStatuses = new List<ApartmentStatus>();
                    while (reader.Read())
                    {
                        apartStatuses.Add(ApartmentStatus.ParseFromReader(reader));
                    }
                    return apartStatuses;
                }
            }
        }

        public IList<AspNetUser> GetAspNetUsers()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetAspNetUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<AspNetUser> usersList = new List<AspNetUser>();
                    while (reader.Read())
                    {
                        usersList.Add(AspNetUser.ParseFromReader(reader));
                    }
                    return usersList;
                }
            }
        }

        public IList<City> GetCitys()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetCitys", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<City> cityList = new List<City>();
                    while (reader.Read())
                    {
                        cityList.Add(City.ParseFromReader(reader));
                    }
                    return cityList;
                }
            }
        }

        public Tag GetTagById(int tagId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetTagById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", tagId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return Tag.ParseFromReader(reader);
                    }
                    return new Tag();
                }
            }
        }

        public IList<Tag> GetTags()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("GetTags", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<Tag> tags = new List<Tag>();
                    while (reader.Read())
                    {
                        tags.Add(Tag.ParseFromReader(reader));
                    }
                    return tags;
                }
            }
        }

        public void UpdateApartmentById(Apartment apartment)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("UpdateApartmentById", connection);
                command.Parameters.AddWithValue("id", apartment.Id);
                command.Parameters.AddWithValue("statusId", apartment.StatusId);
                command.Parameters.AddWithValue("totalRooms", apartment.TotalRooms);
                command.Parameters.AddWithValue("maxAdults", apartment.MaxAdults);
                command.Parameters.AddWithValue("maxChildren", apartment.MaxChildren);
                command.Parameters.AddWithValue("beachDistance", apartment.BeachDistance);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public void CreateApartmentReservationRegisteredUser(ApartmentReservation reservation)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("CreateApartmentReservationRegisteredUser", connection);
                command.Parameters.AddWithValue("createdAt", reservation.CreatedAt);
                command.Parameters.AddWithValue("apartmentId", reservation.ApartmentId);
                command.Parameters.AddWithValue("details", reservation.Details);
                command.Parameters.AddWithValue("userId", reservation.UserId);
                command.CommandType=System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public void CreateApartmentReservationNonRegisteredUser(ApartmentReservation reservation)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("CreateApartmentReservationNonRegisteredUser", connection);
                command.Parameters.AddWithValue("createdAt", reservation.CreatedAt);
                command.Parameters.AddWithValue("apartmentId", reservation.ApartmentId);
                command.Parameters.AddWithValue("details", reservation.Details);
                command.Parameters.AddWithValue("userName", reservation.UserName);
                command.Parameters.AddWithValue("userEmail", reservation.UserEmail);
                command.Parameters.AddWithValue("userPhone", reservation.UserPhone);
                command.Parameters.AddWithValue("userAddress", reservation.UserAddress);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public IList<Apartment> GetApartmentsFilteredByStatusCity(int statusId, int cityId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(GetApartmentsFilteredByStatusCity), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("statusId", statusId);
                command.Parameters.AddWithValue("cityId", cityId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<Apartment> filteredApartments = new List<Apartment>();
                    while (reader.Read())
                    {
                        filteredApartments.Add(Apartment.ParseFromReader(reader));
                    }
                    return filteredApartments;
                }
            }
        }

        public IList<Tag> GetApartmentTags(int apartmentId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(GetApartmentTags), connection);
                command.Parameters.AddWithValue("apartmentId", apartmentId);
                command.CommandType=System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<Tag> apartmentTags = new List<Tag>();
                    while (reader.Read())
                    {
                        apartmentTags.Add(Tag.ParseFromReader(reader));
                    }
                    return apartmentTags;
                }
            }
        }

        public void InsertTagToApartment(int apartmentId, int tagId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(InsertTagToApartment), connection);
                command.Parameters.AddWithValue("apartmentId", apartmentId);
                command.Parameters.AddWithValue("tagId", tagId);
                command.Parameters.AddWithValue("guid", Guid.NewGuid());
                command.CommandType = System.Data.CommandType.StoredProcedure; 
                command.ExecuteNonQuery();
            }
        }

        public void RegisterUser(AspNetUser user)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(RegisterUser), connection);
                command.Parameters.AddWithValue("email", user.Email);
                command.Parameters.AddWithValue("passwordHash", user.PasswordHash);
                command.Parameters.AddWithValue("phoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("userName", user.UserName);
                command.Parameters.AddWithValue("address", user.Address);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public AspNetUser AuthUser(string userName, string hashedPassword)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(AuthUser), connection);
                command.Parameters.AddWithValue("userName", userName);
                command.Parameters.AddWithValue("hashedPassword", hashedPassword);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return AspNetUser.ParseFromReader(reader);
                    }
                    return null;
                }
            }
        }

        public void InsertUserReview(ApartmentReview review)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(InsertUserReview), connection);
                command.Parameters.AddWithValue("userId", review.UserId);
                command.Parameters.AddWithValue("apartmentId", review.ApartmentId);
                command.Parameters.AddWithValue("details", review?.Details);
                command.Parameters.AddWithValue("stars", review.Stars);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public void InsertApartmentPicture(ApartmentPicture picture)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(InsertApartmentPicture), connection);
                command.Parameters.AddWithValue("apartmentId", picture.ApartmentId);
                command.Parameters.AddWithValue("size", picture.Size);
                command.Parameters.AddWithValue("imageData", picture.ImageData);
                command.Parameters.AddWithValue("name", picture.Name);
                command.Parameters.AddWithValue("isRepresentative", picture.IsRepresentative);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public IList<ApartmentPicture> GetAllApartmentPictures(int apartmentId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(GetAllApartmentPictures), connection);
                command.Parameters.AddWithValue("apartmentId", apartmentId);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<ApartmentPicture> list = new List<ApartmentPicture>();
                    while (reader.Read())
                    {
                        list.Add(ApartmentPicture.ParseFromReader(reader));
                    }
                    return list;
                }
            }
        }

        public void SoftDeleteApartmentPicture(int pictureId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(SoftDeleteApartmentPicture), connection);
                command.Parameters.AddWithValue("pictureId", pictureId);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public void UpdateApartmentMainPicture(int pictureId, int apartmentId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(UpdateApartmentMainPicture), connection);
                command.Parameters.AddWithValue("pictureId", pictureId);
                command.Parameters.AddWithValue("apartmentId", apartmentId);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public ApartmentPicture GetApartMainPicture(int apartmentId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(GetApartMainPicture), connection);
                command.Parameters.AddWithValue("apartmentId", apartmentId);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return ApartmentPicture.ParseFromReader(reader);
                }
            }
        }

        public void DeleteTagFromApartment(int apartmentId, int tagId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(nameof(DeleteTagFromApartment), connection);
                command.Parameters.AddWithValue("apartmentId", apartmentId);
                command.Parameters.AddWithValue("tagId", tagId);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }
    }
}