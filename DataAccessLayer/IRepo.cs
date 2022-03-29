using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepo
    {
        IList<string> GetApartments();
        void GetApartmentById(int apartmentId);      
        void CreateApartment();
        void UpdateApartmentById(int apartmentId);
        void DeleteApartmentById(int aparmentId);
        IList<string> GetTags();
        void DeleteTagById(int tagId);
        void CreateTag();

    }
}
