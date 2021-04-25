using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerApartmentProject.Repositories
{
    public class EquipmentRes : IEquipmentRes
    {
        private readonly Func<DataRow, Equipment> _func;
        private readonly SQLCommand _connection;
        public EquipmentRes()
        {
            _func = (DataRow row) => SQLCommand.Map<Equipment>(row);
            _connection = DataProvider.INSTANCE;
        }
        #region List 
        public List<Equipment> GetAll()
        {
            return DataProvider.GetListFrom<Equipment>(
                                    "Equipment_GetAll",
                                    null,
                                    _func
                                );

        }
        #endregion

        #region Item
        public Equipment GetByID(int ID)
        {
            Equipment item = new Equipment();
            
            object[] value = { ID };
            DataTable result = _connection.Select("Equipment_GetById", value);
            if (_connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Equipment>(result.Rows[0]);
            }
            return item;
        }
        #endregion

        public bool Insert(Equipment equipment)
        {
            object[] value = {
                  equipment.name,
                  equipment.count,
                  equipment.equipmentOf
            };
            
            bool result = _connection.ExecuteData("Equipment_Insert", value);

            return result;
        }
        public bool DeleteById(int id)
        {
            object[] value = {
               id
            };
            
            bool result = _connection.ExecuteData("Equipment_DeleteById", value);

            return result;
        }

        public bool UpdateById(int id, Equipment equipment)
        {
            object[] value = {
                id,
                equipment.name,
                equipment.count,
                equipment.equipmentOf
            };
            
            bool result = _connection.ExecuteData("Equipment_EditById", value);

            return result;
        }
    }
}
