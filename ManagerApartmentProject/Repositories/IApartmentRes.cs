using System.Collections.Generic;
using ManagerApartmentProject.Models;
// using ManagerApartmentProject.Repositories.ApartmentRes;
namespace ManagerApartmentProject.Repositories
{
    public interface IApartmentRes
    {
        public List<Apartment> GetAll();
        public Apartment GetByID(int ID);
        public bool Insert(Apartment apartment);
        public bool DeleteById(int id);
        public bool UpdateById(int id, Apartment apartment);
        public List<ApartmentModel> GetIdNameAll();
    }
}