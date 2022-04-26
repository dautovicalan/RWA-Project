using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Dal
{
    public class DatabaseRepo : IRepo
    {
        private string connectionString = "Data Source=DESKTOP-F08V67G;Initial Catalog=RwaApartmani;Integrated Security=True";

        private SqlConnection connection;
        private SqlCommand command;

        public void CreateApartment(Apartment apartment)
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
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
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
                    return new Apartment();
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
                command.Parameters.AddWithValue("guid", reservation.Guid);
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
                command.Parameters.AddWithValue("guid", reservation.Guid);
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
    }
}