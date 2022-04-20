using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dal
{
    public interface IRepo
    {
        IList<Apartment> GetApartments();
        Apartment GetApartmentById(int apartmentId);      
        void CreateApartment();
        Apartment UpdateApartmentById(int apartmentId);
        void DeleteApartmentById(int aparmentId);
        IList<ApartmentStatus> GetApartmentStatuses();
        IList<ApartmentOwner> GetApartmentOwners();
        IList<Tag> GetTags();
        Tag GetTagById(int tagId);
        void DeleteTagById(int tagId);
        void CreateTag(Tag tag);

        IList<AspNetUser> GetAspNetUsers();


        IList<City> GetCitys();

    }
}
