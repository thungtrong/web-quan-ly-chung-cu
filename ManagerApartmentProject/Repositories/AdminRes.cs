using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Repositories{
    public class AdminRes : IAdminRes
    {
        private readonly Func<DataRow, Admin> _func;
        public AdminRes(){
            _func = (DataRow row) => SQLCommand.Map<Admin>(row);
        }

        public bool Create(Admin admin, int creatorID)
        {
            object[] values = {
                admin.name,
                admin.email,
                admin.phoneNumber,
                admin.status,
                admin.description,
                creatorID
            };
            return DataProvider.INSTANCE.ExecuteData("Admin_Add", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Admin_DeleteById", new object[] {id});
        }

        public bool EditById(int id, Admin admin)
        {
            object[] values = {
                id,
                admin.name,
                admin.email,
                admin.phoneNumber,
                admin.status,
                admin.description
            };
            return DataProvider.INSTANCE.ExecuteData("Admin_EditById", values);
        }

        public List<Admin> GetAll()
        {
            return DataProvider.GetListFrom<Admin>(
                "Admin_GetAll",
                null,
                _func
            );
        }

        public Admin GetById(int id)
        {
            return DataProvider.GetObjectByIdFrom<Admin>(
                "Admin_GetById",
                id,
                _func
            );
        }


    }
}