using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface ITenantRes
    {
        List<Tenant> GetAll();
        Tenant GetById(int id);
        bool EditById(int id, Tenant tenant);
        bool DeleteById(int id);
        bool Create(Tenant tenant);
    }
}