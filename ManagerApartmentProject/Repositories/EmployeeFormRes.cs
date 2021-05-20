using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerApartmentProject.Repositories
{
    public interface IEmployeeFormRes
    {
        List<EmployeeForm> EmployeeForm_GetAll();
        List<EmployeeForm> EmployeeForm_GetAll_ById(int id);
        EmployeeForm EmployeeForm_GetById(int id);
        bool EmployeeForm_Insert(EmployeeForm employeeform,int creatorid);
        bool EmployeeForm_DeleteByID(int id);
        bool UpdateById(int id, EmployeeForm employeeform);

    }
    public class EmployeeFormRes : IEmployeeFormRes
    {
        private readonly Func<DataRow, EmployeeForm> _func;
        private readonly SQLCommand _connection;
        public EmployeeFormRes()
        {
            _func = (DataRow row) => SQLCommand.Map<EmployeeForm>(row);
            _connection = DataProvider.INSTANCE;
        }
        #region List 
        public List<EmployeeForm> EmployeeForm_GetAll()
        {
            return DataProvider.GetListFrom<EmployeeForm>(
                "EmployeeForm_GetAll",
                null,
                _func
            );
        }
        public List<EmployeeForm> EmployeeForm_GetAll_ById(int id)
        {
            return DataProvider.GetListFrom<EmployeeForm>(
                "EmployeeForm_GetAll_ById",
                new object[] { id },
                _func
            );
        }

        #endregion

        #region Item
        public EmployeeForm EmployeeForm_GetById(int ID)
        {

            return DataProvider.GetObjectByIdFrom<EmployeeForm>(
                "EmployeeForm_GetById",
                ID,
                _func
                );
        }
        #endregion

        public bool EmployeeForm_Insert(EmployeeForm employeeform, int creatorid)
        {
            object[] value = {                 
                  employeeform.title,
                  employeeform.content,
                  employeeform.dateRelease,
                  employeeform.status,
                  creatorid

            };

            bool result = _connection.ExecuteData("EmployeeForm_Insert", value);

            return result;
        }


        public bool EmployeeForm_DeleteByID(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("EmployeeForm_DeleteByID", new object[] { id });
        }

        public bool UpdateById(int id, EmployeeForm employeeform)
        {
            object[] value = {
                    id,
                    employeeform.status
            };

            bool result = _connection.ExecuteData("EmployeeForm_EditById", value);

            return result;
        }


    }
}
