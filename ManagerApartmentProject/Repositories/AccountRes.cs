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
    }

    public class AccountRes : IAccountRes
    {
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
    }


}