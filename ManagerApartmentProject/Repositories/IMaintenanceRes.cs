using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IMaintenanceRes
    {
        List<Maintenance> GetAll();
        Maintenance GetById(int id);
        bool EditById(int id, Maintenance maintenance);
        bool DeleteById(int id);
        bool Create(Maintenance maintenance, int creatorId);
    }
}