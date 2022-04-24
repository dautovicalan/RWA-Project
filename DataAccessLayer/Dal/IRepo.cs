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
        void CreateApartment(Apartment apartment);
        void UpdateApartmentById(Apartment apartment);
        void SoftDeleteApartmentById(int aparmentId);
        IList<ApartmentStatus> GetApartmentStatuses();
        IList<ApartmentOwner> GetApartmentOwners();
        IList<Tag> GetTags();
        Tag GetTagById(int tagId);
        void DeleteTagById(int tagId);
        void CreateTag(Tag tag);

        void CreateApartmentReservationRegisteredUser(ApartmentReservation reservation);

        void CreateApartmentReservationNonRegisteredUser(ApartmentReservation reservation);

        IList<AspNetUser> GetAspNetUsers();


        IList<City> GetCitys();

    }
}
