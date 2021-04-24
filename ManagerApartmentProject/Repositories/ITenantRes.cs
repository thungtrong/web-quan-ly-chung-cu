using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface ITenantRes
    {
        List<Tenant> GetAll();
        Tenant GetById(int id);
        bool EditById(int id, Tenant maintenance);
        bool DeleteById(int id);
        bool Create(Tenant maintenance, int creatorId);
    }
}