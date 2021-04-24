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

        public bool UpdateById(int id, InvoiceApartmentViewModel model)
        {
            object[] values = {
                model.invoice.ID,
                model.invoice.dateRelease,
                model.invoice.datePaid,
                model.invoice.status,
            };
            bool result = DataProvider.INSTANCE.ExecuteData("InvoiceApartment_EditById", values);
            
            object[] values1 = new object[] {
                0,
                0,
                0
            };
            foreach (var detail in model.details)
            {
                values1[0] = detail.ID;
                values1[1] = detail.name;
                values1[2] = detail.amount;
                
                if (detail.ID != 0 ){
                    result = result && DataProvider.INSTANCE.ExecuteData("DetailInvoice_EditById", values1);
                } else {
                    values1[0] = model.invoice.ID;
                    result = result && DataProvider.INSTANCE.ExecuteData("DetailInvoice_Create", values1);
                }
            }
            return result;
        }
    }
}