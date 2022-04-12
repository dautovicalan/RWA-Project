using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Dal
{
    internal class DatabaseRepo : IRepo
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

        public void CreateTag()
        {
            throw new System.NotImplementedException();
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

        public IList<Tag> GetTags()
        {
            throw new System.NotImplementedException();
        }

        public Apartment UpdateApartmentById(int apartmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}