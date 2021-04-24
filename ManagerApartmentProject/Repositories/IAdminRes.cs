using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IAdminRes
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        bool EditById(int id, Admin maintenance);
        bool DeleteById(int id);
        bool Create(Admin maintenance, int creatorId);
    }
}