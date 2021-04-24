using CAIT.SQLHelper;
using ManagerAparmentProject.Const;
using ManagerAparmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerAparmentProject.Repositories
{
    public class EquipmentRes
    {
        #region List 
        public static List<Equipment> GetAll()
        {
            List<Equipment> lstMember = new List<Equipment>();
            object[] value = null;
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Equipment_GetAll", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Equipment member = SQLCommand.Map<Equipment>(dr);
                    lstMember.Add(member);
                }
            }
            return lstMember;
        }

        internal static Equipment GetByID(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Item
        public static Equipment GetByID(int ID)
        {
            Equipment item = new Equipment();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { ID };
            DataTable result = connection.Select("Equipment_GetById", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Equipment>(result.Rows[0]);
            }
            return item;
        }
        #endregion
        #region delete
        public static bool DeleteByIDs(DataTable dt, ref string[] output, ref int errorCode, ref string errorMessage)
        {
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteDataTable("equipments_Delete", dt);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        #endregion
        public static bool Insert(Equipment equipment)
        {
            object[] value = {
                  equipment.name,
                  equipment.count,
                  equipment.equipment_of
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Equipment_Insert", value);

            return result;
        }
        public static bool Delete(int id)
        {
            object[] value = {
               id
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Equipment_DeleteById", value);

            return result;
        }

        public static bool Update(int id, Equipment equipment)
        {
            object[] value = {
                id,
                equipment.name,
                equipment.count,
                equipment.equipment_of
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Equipment_EditById", value);

            return result;
        }
    }
}
