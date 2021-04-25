using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject
{
    public interface IFloorRes
    {
        List<Floor> GetAll();
        Floor GetByID(int id);
        bool Insert(Floor apartment);
        bool UpdateById(int id, Floor apartment);
        bool DeleteById(int id);
    }
}