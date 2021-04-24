using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("invoice,details")]
    public class InvoiceApartmentViewModel
    {
        public InvoiceApartment invoice { get; set; }
        public List<DetailInvoice> details { get; set; }
    }
}