using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerApartmentProject.Repositories
{
    public class FloorRes : IFloorRes
    {
        private readonly Func<DataRow, Floor> _func;
        private readonly SQLCommand _connection;
        public FloorRes(){
            _func = (DataRow row) => SQLCommand.Map<Floor>(row);
            _connection = DataProvider.INSTANCE;
        }
        #region List 
        public List<Floor> GetAll()
        {
            return DataProvider.GetListFrom<Floor>(
                "Floor_GetAll",
                null,
                _func
            );
        }

        #endregion

        #region Item
        public Floor GetByID(int ID)
        {
            
            return DataProvider.GetObjectByIdFrom<Floor>(
                "Floor_GetById",
                ID,
                _func
                );
        }
        #endregion

        public bool Insert(Floor floor)
        {
            object[] value = {
                  floor.name,
                  floor.description
            };
            
            bool result = _connection.ExecuteData("Floor_Insert", value);

            return result;
        }
        public bool DeleteById(int id)
        {
            object[] value = {
               id
            };
            
            bool result = _connection.ExecuteData("Floor_DeleteById", value);

            return result;
        }

        public bool UpdateById(int id, Floor floor)
        {
            object[] value = {
                id,
                floor.name,
                floor.description
            };
            
            bool result = _connection.ExecuteData("Floor_EditById", value);

            return result;
        }
    }
}
