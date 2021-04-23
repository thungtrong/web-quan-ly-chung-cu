using ManagerAparmentProject.Const;
using ManagerAparmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerAparmentProject.Repositories
{
    public class FloorRes
    {
        #region List 
        public static List<Floor> GetAll()
        {
            List<Floor> lstMember = new List<Floor>();
            object[] value = null;
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Floors_GetAll", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Floor member = SQLCommand.Map<Floor>(dr);
                    lstMember.Add(member);
                }
            }
            return lstMember;
        }

        internal static Floor GetByID(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Item
        public static Floor GetByID(int ID)
        {
            Floor item = new Floor();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { ID };
            DataTable result = connection.Select("Floor_GetById", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Floor>(result.Rows[0]);
            }
            return item;
        }
        #endregion
        #region delete
        public static bool DeleteByIDs(DataTable dt, ref string[] output, ref int errorCode, ref string errorMessage)
        {
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteDataTable("floors_Delete", dt);
            output = connection.output;
            errorCode = connection.errorCode;
            errorMessage = connection.errorMessage;
            return result;
        }
        #endregion
        public static bool Insert(Floor floor)
        {
            object[] value = {
                  floor.id,
                  floor.name,
                  floor.description
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Floor_Insert", value);

            return result;
        }
        public static bool Delete(int id)
        {
            object[] value = {
               id
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Floor_DeleteById", value);

            return result;
        }

        public static bool Update(int id, Floor floor)
        {
            object[] value = {
                id,
                floor.name,
                floor.description
            };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            bool result = connection.ExecuteData("Floor_EditById", value);

            return result;
        }
    }
}
