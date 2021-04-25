using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagerApartmentProject.Repositories
{
    public class ApartmentRes : IApartmentRes
    {
        private readonly SQLCommand _connection;
        private readonly Func<DataRow, Apartment> _func;
        public ApartmentRes()
        {
            _connection = DataProvider.INSTANCE;
            _func = (DataRow row) => SQLCommand.Map<Apartment>(row);
        }
        #region List 
        public List<Apartment> GetAll()
        {

            return DataProvider.GetListFrom<Apartment>(
                "Apartment_GetAll",
                null,
                _func);
        }
        #endregion
        #region Item
        public Apartment GetByID(int ID)
        {

            return DataProvider.GetObjectByIdFrom<Apartment>(
                "Apartment_GetById",
                ID,
                _func
            );
        }

        #endregion

        public bool Insert(Apartment apartment)
        {
            object[] value = {
                apartment.name,
                apartment.floor,
                apartment.description,
                apartment.status,
            };

            bool result = _connection.ExecuteData("Apartment_Insert", value);

            return result;
        }
        public bool DeleteById(int id)
        {
            object[] value = {
               id
            };

            bool result = _connection.ExecuteData("Apartment_DeleteById", value);

            return result;
        }

        public bool UpdateById(int id, Apartment apartment)
        {
            object[] value = {
                id,
                apartment.name,
                apartment.floor,
                apartment.status,
                apartment.paymentPerMonth,
                apartment.description
            };

            bool result = _connection.ExecuteData("Apartment_EditByID", value);

            return result;
        }

        public List<ApartmentModel> GetIdNameAll()
        {
            return DataProvider.GetListFrom<ApartmentModel>(
                            "Apartment_GetIdNameAll",
                            null,
                            (DataRow row) => SQLCommand.Map<ApartmentModel>(row));
        }
    }
}
