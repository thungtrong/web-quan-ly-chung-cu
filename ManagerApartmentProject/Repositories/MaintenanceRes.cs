using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Repositories{
    public interface IMaintenanceRes
    {
        List<Maintenance> GetAll();
        Maintenance GetById(int id);
        bool EditById(int id, Maintenance maintenance);
        bool DeleteById(int id);
        bool Create(Maintenance maintenance, int creatorId);
    }
    public class MaintenanceRes : IMaintenanceRes
    {
        private readonly Func<DataRow, Maintenance> _func;
        public MaintenanceRes(){
            _func = (DataRow row) => SQLCommand.Map<Maintenance>(row);
        }

        public bool Create(Maintenance maintenance, int creatorID)
        {
            object[] values = {
                maintenance.title,
                maintenance.dateCreate,
                maintenance.amount,
                maintenance.status,
                maintenance.description,
                creatorID
            };
            return DataProvider.INSTANCE.ExecuteData("Maintenance_Add", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Maintenance_DeleteById", new object[] {id});
        }

        public bool EditById(int id, Maintenance maintenance)
        {
            object[] values = {
                id,
                maintenance.title,
                maintenance.dateCreate,
                maintenance.amount,
                maintenance.status,
                maintenance.description
            };
            return DataProvider.INSTANCE.ExecuteData("Maintenance_EditById", values);
        }

        public List<Maintenance> GetAll()
        {
            return DataProvider.GetListFrom<Maintenance>(
                "Maintenance_GetAll",
                null,
                _func
            );
        }

        public Maintenance GetById(int id)
        {
            return DataProvider.GetObjectByIdFrom<Maintenance>(
                "Maintenance_GetById",
                id,
                _func
            );
        }


    }
}