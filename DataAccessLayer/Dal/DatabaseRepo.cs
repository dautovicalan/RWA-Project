using DataAccessLayer.Model;
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
            throw new System.NotImplementedException();
        }

        public IList<Apartment> GetApartments()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM Apartment", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<Apartment> list = new List<Apartment>();
                    while (reader.Read())
                    {
                        list.Add(new Apartment
                        {
                            Guid = (System.Guid)reader["Guid"]
                        });
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