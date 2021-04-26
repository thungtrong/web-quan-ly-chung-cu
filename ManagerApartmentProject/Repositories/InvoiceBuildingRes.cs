using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories{
    public interface IInvoiceBuildingRes
    {
        List<InvoiceBuilding> GetAll();
        bool Create(InvoiceBuilding maintenance, int creatorId);
        InvoiceBuilding GetById(int id);
        bool EditById(int id, InvoiceBuilding maintenance);
        bool DeleteById(int id);
    }
    public class InvoiceBuildingRes : IInvoiceBuildingRes{
        private readonly Func<DataRow, InvoiceBuilding> _func;
        public InvoiceBuildingRes(){
            _func = (DataRow row) => SQLCommand.Map<InvoiceBuilding>(row);
        }

        public bool Create(InvoiceBuilding maintenance, int creatorID)
        {
            object[] values = {
                maintenance.title,
                maintenance.dateCreate,
                maintenance.amount,
                maintenance.status,
                maintenance.description,
                creatorID
            };
            return DataProvider.INSTANCE.ExecuteData("InvoiceBuilding_Add", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("InvoiceBuilding_DeleteById", new object[] {id});
        }

        public bool EditById(int id, InvoiceBuilding maintenance)
        {
            object[] values = {
                id,
                maintenance.title,
                maintenance.dateCreate,
                maintenance.amount,
                maintenance.status,
                maintenance.description
            };
            return DataProvider.INSTANCE.ExecuteData("InvoiceBuilding_EditById", values);
        }

        public List<InvoiceBuilding> GetAll()
        {
            return DataProvider.GetListFrom<InvoiceBuilding>(
                "InvoiceBuilding_GetAll",
                null,
                _func
            );
        }

        public InvoiceBuilding GetById(int id)
        {
            return DataProvider.GetObjectByIdFrom<InvoiceBuilding>(
                "InvoiceBuilding_GetById",
                id,
                _func
            );
        }

    }
}