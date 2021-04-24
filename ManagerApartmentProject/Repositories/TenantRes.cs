using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Repositories{
    public class TenantRes : ITenantRes
    {
        private readonly Func<DataRow, Tenant> _func;
        public TenantRes(){
            _func = (DataRow row) => SQLCommand.Map<Tenant>(row);
        }

        public bool Create(Tenant tenant, int creatorID)
        {
            object[] values = {
                tenant.ID,
                tenant.name,
                tenant.email,
                tenant.phoneNumber,
                tenant.advancePayment,
                tenant.paymentPerMonth,
                tenant.status,
                tenant.unitNo,
                creatorID
            };
            return DataProvider.INSTANCE.ExecuteData("Tenant_Add", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Tenant_DeleteById", new object[] {id});
        }

        public bool EditById(int id, Tenant tenant)
        {
            object[] values = {
                id,
                
                tenant.name,
                tenant.email,
                tenant.phoneNumber,
                tenant.advancePayment,
                tenant.paymentPerMonth,
                tenant.status,
                tenant.unitNo,
            };
            return DataProvider.INSTANCE.ExecuteData("Tenant_EditById", values);
        }

        public List<Tenant> GetAll()
        {
            return DataProvider.GetListFrom<Tenant>(
                "Tenant_GetAll",
                null,
                _func
            );
        }

        public Tenant GetById(int id)
        {
            return DataProvider.GetObjectByIdFrom<Tenant>(
                "Tenant_GetById",
                id,
                _func
            );
        }


    }
}