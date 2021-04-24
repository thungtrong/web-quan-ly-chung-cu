using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IEmployeeRes
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        bool EditById(int id, Employee maintenance);
        bool DeleteById(int id);
        bool Create(Employee maintenance, int creatorId);
    }
}