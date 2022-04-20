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

        public void CreateApartment()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("Insert Into City (Guid, Name) Values(@guid, @name)", connection);
                command.Parameters.AddWithValue("@guid", "d2a78f5e-d74c-4410-8882-9f738deca876");
                command.Parameters.AddWithValue("@name", "test");
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

        public void DeleteApartmentById(int aparmentId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTagById(int tagId)
        {
            throw new System.NotImplementedException();
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

        public Apartment UpdateApartmentById(int apartmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}