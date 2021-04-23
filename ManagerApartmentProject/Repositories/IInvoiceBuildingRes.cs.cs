using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IInvoiceBuildingRes
    {
        List<InvoiceBuilding> GetAll();
        bool Create(InvoiceBuilding maintenance, int creatorId);
        InvoiceBuilding GetById(int id);
        bool EditById(int id, InvoiceBuilding maintenance);
        bool DeleteById(int id);
    }
}