using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Repositories{
    public class EmployeeRes : IEmployeeRes
    {
        private readonly Func<DataRow, Employee> _func;
        public EmployeeRes(){
            _func = (DataRow row) => SQLCommand.Map<Employee>(row);
        }

        public bool Create(Employee employee, int creatorID)
        {
            object[] values = {
                employee.ID,
                employee.name,
                employee.address,
                employee.email,
                employee.phoneNumber, 
                employee.salary,
                employee.join_date,
                employee.position,
                employee.description,
                creatorID
            };
            return DataProvider.INSTANCE.ExecuteData("Employee_Add", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Employee_DeleteById", new object[] {id});
        }

        public bool EditById(int id, Employee employee)
        {
            object[] values = {
                id,
               employee.name,
                employee.address,
                employee.email,
                employee.phoneNumber, 
                employee.salary,
                employee.join_date,
                employee.position,
                employee.description,
            };
            return DataProvider.INSTANCE.ExecuteData("Employee_EditById", values);
        }

        public List<Employee> GetAll()
        {
            return DataProvider.GetListFrom<Employee>(
                "Employee_GetAll",
                null,
                _func
            );
        }

        public Employee GetById(int id)
        {
            return DataProvider.GetObjectByIdFrom<Employee>(
                "Employee_GetById",
                id,
                _func
            );
        }


    }
}