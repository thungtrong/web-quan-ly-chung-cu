using System.Threading.Tasks;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface IAccountRes
    {
        public PersonModel GetPersonTenantByUserNamePassword(Account account);
        public PersonModel GetPersonEmployeeByUserNamePassword(Account account);
        public PersonModel GetPersonAdminByUserNamePassword(Account account);
        public bool CreateAccount(Account account);
        bool RePassword(Account account);
    }

    public class AccountRes : IAccountRes
    {
        public bool CreateAccount(Account account)
        {
            if (account != null)
            {
                object[] values =  new object[] {
                    account.username,
                    account.password,
                    account.accountOf
                };
                // Admin
                if (account.authority == 1)
                {
                    return DataProvider.INSTANCE.ExecuteData("AdminAccount_Create", values);
                }
                // Employee
                if (account.authority == 2)
                {
                    return DataProvider.INSTANCE.ExecuteData("EmployeeAccount_Create", values);
                }
                // Tenant
                if (account.authority == 3)
                {
                    return DataProvider.INSTANCE.ExecuteData("TenantAccount_Create", values);
                }
            }
            return false;
        }

        public PersonModel GetPersonAdminByUserNamePassword(Account account)
        {
            var person = DataProvider
                        .GetPersonByValuesFrom(
                            "AdminAccount_GetByUserNamePassword",
                            new object[] { 
                                account.username,
                                account.password,
                                account.authority
                            }
                        );
            return person;
        }

        public PersonModel GetPersonEmployeeByUserNamePassword(Account account)
        {
            var person = DataProvider
                        .GetPersonByValuesFrom(
                            "EmployeeAccount_GetByUserNamePassword",
                            new object[] {
                            account.username,
                            account.password
                            }
                        );
            return person;
        }

        public PersonModel GetPersonTenantByUserNamePassword(Account account)
        {
            var person = DataProvider
                        .GetPersonByValuesFrom(
                            "TenantAccount_GetByUserNamePassword",
                            new object[] {
                                account.username,
                                account.password
                            }
                        );
            return person;
        }

        public bool RePassword(Account account)
        {
            object[] values = new object[] {
                account.password,
                account.newPassword,
                account.accountOf
            };

            // Admin
            if (account.authority == 1 || account.authority == 0)
            {
                bool result = DataProvider.INSTANCE.ExecuteData("AdminAccount_EditPassword", values);
                return result;
            }
            // Employee
            if (account.authority == 2)
            {
                return DataProvider.INSTANCE.ExecuteData("EmployeeAccount_EditPassword", values);
            }
            // Tenant
            if (account.authority == 3)
            {
                return DataProvider.INSTANCE.ExecuteData("TenantAccount_EditPassword", values);
            }
            return false;
        }
    }


}