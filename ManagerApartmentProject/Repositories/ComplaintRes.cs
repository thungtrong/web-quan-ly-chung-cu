using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerApartmentProject.Repositories
{
    public interface IComplaintRes
    {
        List<Complaint> Complaint_GetAll();
        List<Complaint> Complaint_Employee_GetAll(int id);
        List<Complaint> Complaint_Tenant_GetAll(int id);
        Complaint Complaint_Employee_GetById(int id);
        Complaint Complaint_Tenant_GetById(int id);
        bool Complaint_Employee_Insert(Complaint complaint,int creatorid);
        bool Complaint_Tenant_Insert(Complaint complaint, int creatorid);
        bool Complaint_Employee_DeleteByID(int id);
        bool Complaint_Tenant_DeleteByID(int id);
    }
    public class ComplaintRes : IComplaintRes
    {
        private readonly Func<DataRow, Complaint> _func;
        private readonly SQLCommand _connection;
        public ComplaintRes(){
            _func = (DataRow row) => SQLCommand.Map<Complaint>(row);
            _connection = DataProvider.INSTANCE;
        }
        #region List 
        public List<Complaint> Complaint_GetAll()
        {
            return DataProvider.GetListFrom<Complaint>(
                "Complaint_GetAll",
                null,
                _func
            );
        }
        public List<Complaint> Complaint_Employee_GetAll(int id)
        {
            return DataProvider.GetListFrom<Complaint>(
                "Complaint_Employee_GetAll",
                new object[] { id },
                _func
            );
        }
         public List<Complaint> Complaint_Tenant_GetAll(int id)
        {
            return DataProvider.GetListFrom<Complaint>(
                "Complaint_Tenant_GetAll",
                new object[] { id },
                _func
            );
        }
        #endregion

        #region Item
        public Complaint Complaint_Employee_GetById(int ID)
        {
            
            return DataProvider.GetObjectByIdFrom<Complaint>(
                "Complaint_Employee_GetById",
                ID,
                _func
                );
        }
        public Complaint Complaint_Tenant_GetById(int ID)
        {

            return DataProvider.GetObjectByIdFrom<Complaint>(
                "Complaint_Tenant_GetById",
                ID,
                _func
                );
        }
        #endregion

        public bool Complaint_Employee_Insert(Complaint complaint,int creatorid)
        {
            object[] value = {
                  complaint.title,
                  complaint.content,
                  complaint.dateRelease,
                  creatorid
            };
            
            bool result = _connection.ExecuteData("Complaint_Employee_Insert", value);

            return result;
        }
        public bool Complaint_Tenant_Insert(Complaint complaint, int creatorid)
        {
            object[] value = {
                  complaint.title,
                  complaint.content,
                  complaint.dateRelease,
                  creatorid
            };

            bool result = _connection.ExecuteData("Complaint_Tenant_Insert", value);

            return result;
        }
        public bool Complaint_Employee_DeleteByID(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Complaint_Employee_DeleteByID", new object[] { id });
        }
        public bool Complaint_Tenant_DeleteByID(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Complaint_Tenant_DeleteByID", new object[] { id });
        }

    }
}
