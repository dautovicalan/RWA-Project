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

        public static Tag ParseFromReader(SqlDataReader reader)
        {
            return new Tag
            {
                Id = reader.GetInt32(0),
                Guid = reader.GetGuid(1),
                TypeId = reader.GetInt32(3),
                Name = reader.GetString(4),
                NameEng = reader.GetString(5)
            };
        }
    }
}
