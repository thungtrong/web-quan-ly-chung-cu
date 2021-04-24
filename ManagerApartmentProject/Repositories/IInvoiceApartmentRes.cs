using System.Collections.Generic;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IInvoiceApartmentRes
    {
        List<InvoiceApartment> GetAll();
        InvoiceApartmentViewModel GetById(int id);
        bool UpdateById(int id, InvoiceApartmentViewModel model);
    }
}