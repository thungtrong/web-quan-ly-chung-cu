using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IEquipmentRes
    {
        List<Equipment> GetAll();
        Equipment GetByID(int id);
        bool Insert(Equipment apartment);
        bool UpdateById(int id, Equipment apartment);
        bool DeleteById(int id);
    }
}