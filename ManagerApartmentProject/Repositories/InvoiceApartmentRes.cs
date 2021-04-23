using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories{
    public class InvoiceApartmentRes : IInvoiceApartmentRes
    {
        private readonly Func<DataRow, InvoiceApartment> _funcInvoice;
        private readonly Func<DataRow, DetailInvoice> _funcDetail;
        public InvoiceApartmentRes()
        {
            _funcInvoice = (DataRow row) => SQLCommand.Map<InvoiceApartment>(row);
            _funcDetail = (DataRow row) => SQLCommand.Map<DetailInvoice>(row);
        }

        public List<InvoiceApartment> GetAll()
        {
            return DataProvider.GetListFrom<InvoiceApartment>(
                "InvoiceApartment_GetAll",
                null,
                _funcInvoice
            );
        }

        public InvoiceApartmentViewModel GetById(int id)
        {
            InvoiceApartment invoice = DataProvider
                                        .GetObjectByIdFrom<InvoiceApartment>(
                                            "InvoiceApartment_GetById",
                                            id,
                                            _funcInvoice
                                        );

            List<DetailInvoice> details = DataProvider
                                        .GetListFrom<DetailInvoice>(
                                            "DetailInvoice_GetByDetailOf",
                                            new object[] {id},
                                            _funcDetail
                                        );

            for (int i = 0; i < details.Count; i++)
            {
                invoice.amount += details[i].amount;
            }
            return new InvoiceApartmentViewModel{invoice = invoice, details = details};
        }
    }
}