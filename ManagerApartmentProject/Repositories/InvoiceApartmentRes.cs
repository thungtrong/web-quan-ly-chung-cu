using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
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
            InvoiceApartment invoice = GetInvoiceById(id);

            List<DetailInvoice> details = GetDetailByInvoiceId(id);
            
            for (int i = 0; i < details.Count; i++)
            {
                invoice.amount += details[i].amount;
            }
            
            return new InvoiceApartmentViewModel { invoice = invoice, details = details };
        }
        private InvoiceApartment GetInvoiceById(int id)
        {
            return DataProvider
                    .GetObjectByIdFrom<InvoiceApartment>(
                        "InvoiceApartment_GetById",
                        id,
                        _funcInvoice
                    );
        }
        /// <summary>
        /// Lấy tất cả các DetailInvoice thuộc Invoice có ID là id
        /// </summary>
        /// <param name="id">id của Invoice</param>
        /// <returns>List<DetailInvoice></returns>
        private List<DetailInvoice> GetDetailByInvoiceId(int id)
        {
            return DataProvider
                    .GetListFrom<DetailInvoice>(
                        "DetailInvoice_GetByDetailOf",
                        new object[] { id },
                        _funcDetail
                    );
        }
        public bool UpdateById(int id, InvoiceApartmentViewModel model)
        {
            // Update thong tin cua invoice
            object[] values = {
                model.invoice.ID,
                model.invoice.dateRelease,
                model.invoice.datePaid,
                model.invoice.status,
            };
            bool result = DataProvider.INSTANCE.ExecuteData("InvoiceApartment_EditById", values);


            // Them hoac cap nhat detail vao invoice
            object[] values1 = new object[] {0, 0, 0};
            foreach (var detail in model.details)
            {
                values1[0] = detail.ID;
                values1[1] = detail.name;
                values1[2] = detail.amount;

                if (detail.ID != 0)
                {
                    result = result && DataProvider.INSTANCE.ExecuteData("DetailInvoice_EditById", values1);
                }
                else
                {
                    values1[0] = model.invoice.ID;
                    result = result && DataProvider.INSTANCE.ExecuteData("DetailInvoice_Create", values1);
                }
            }
            return result;
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("InvoiceApartment_DeleteById", new object[] {id});;
        }

        public bool Create(int tenantId, InvoiceApartmentViewModel model)
        {
            object[] values = {
                model.invoice.dateRelease,
                model.invoice.datePaid,
                model.invoice.status,
                tenantId
            };
            DataTable dt = DataProvider.INSTANCE.Select("InvoiceApartment_Create", values);
            var id = dt.Rows[0].ItemArray[0];
            bool result = true;
            object[] values1 = new object[] {0, 0, 0};

            foreach (var detail in model.details)
            {
                values1[0] = id;
                values1[1] = detail.name;
                values1[2] = detail.amount;

                result = result && DataProvider.INSTANCE.ExecuteData("DetailInvoice_Create", values1);
            }

            return result;
        }
    }
}