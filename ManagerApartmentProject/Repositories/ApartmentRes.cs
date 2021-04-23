using ManagerAparmentProject.Const;
using ManagerAparmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerAparmentProject.Repositories
{
    public class ApartmentRes
    {
        #region List 
        public static List<Apartment> GetAll()
        {
            List<Apartment> lstMember = new List<Apartment>();
            object[] value = null;
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Apartments_GetAll", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Apartment member = SQLCommand.Map<Apartment>(dr);
                    lstMember.Add(member);
                }
            }
            return lstMember;
        }
        #endregion
        #region Item
        public static Apartment GetByID(int ID)
        {
            Apartment item = new Apartment();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { ID };
            DataTable result = connection.Select("Apartment_GetById", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Apartment>(result.Rows[0]);
            }
            return item;
        }

        internal static Apartment GetByID(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region delete
        public static bool DeleteByIDs(DataTable dt, ref string[] output, ref int errorCode, ref string errorMessage)
        {
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteDataTable("apartments_Delete", dt);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        #endregion
        public static bool Insert(Apartment apartment)
        {
            object[] value = {
                  apartment.id,
                  apartment.name,
                  apartment.floor,
                  apartment.description,
                  apartment.status
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Apartment_Insert", value);

            return result;
        }
        public static bool Delete(int id)
        {
            object[] value = {
               id
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Apartment_DeleteById", value);

            return result;
        }

        public static bool Update(int id, Apartment apartment)
        {
            object[] value = {
                id,
               apartment.name,
               apartment.floor,
               apartment.description,
               apartment.status
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Apartment_EditById", value);

            return result;
        }
    }
}
