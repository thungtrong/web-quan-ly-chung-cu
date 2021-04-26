using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Repositories
{
    public interface IEmployeeRes
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        bool EditById(int id, Employee employee);
        bool DeleteById(int id);
        bool Create(Employee employee);
    }
    public class EmployeeRes : IEmployeeRes
    {
        private readonly Func<DataRow, Employee> _func;
        public EmployeeRes()
        {
            _func = (DataRow row) => SQLCommand.Map<Employee>(row);
        }

        public bool Create(Employee employee)
        {
            object[] values = {
                employee.name,
                employee.email,
                employee.phoneNumber,
                employee.address,
                employee.joinDate,
                employee.salary,
                employee.description
            };
            return DataProvider.INSTANCE.ExecuteData("Employee_Create", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Employee_DeleteById", new object[] { id });
        }

        public bool EditById(int id, Employee employee)
        {
            object[] values = {
                id,
               employee.name,
                employee.email,
                employee.phoneNumber,
                employee.address,
                employee.joinDate,
                employee.salary,
                employee.description
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