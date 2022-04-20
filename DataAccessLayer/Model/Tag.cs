using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public int AppearanceCount { get; set; }

        public static Tag ParseFromReader(SqlDataReader reader)
        {
            return new Tag
            {
                Id = reader.GetInt32(0),
                Guid = reader.GetGuid(1),
                TypeId = reader.GetInt32(3),
                Name = reader.GetString(4),
                NameEng = reader.GetString(5),
                AppearanceCount = GetTagCount(reader.GetInt32(0)),

            };
        }

        private static int GetTagCount(int tagId)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-F08V67G;Initial Catalog=RwaApartmani;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("TagCount", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("id", tagId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    return 0;
                }

            }
        }
    }
}
