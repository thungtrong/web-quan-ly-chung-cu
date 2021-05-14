using System;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IAdminRes
    {
        PersonModel GetAdminById(int id);
    }

    public class AdminRes : IAdminRes
    {
        private readonly Func<DataRow, PersonModel> _func;
        public AdminRes()
        {
            _func = (DataRow row) => SQLCommand.Map<PersonModel>(row);
        }
        public PersonModel GetAdminById(int id)
        {
            return DataProvider.GetObjectByIdFrom<PersonModel>(
                "Admin_GetById",
                id,
                _func
            );
        }
    }
}