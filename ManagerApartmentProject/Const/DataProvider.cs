using CAIT.SQLHelper;

namespace ManagerApartmentProject.Const
{
    public class DataProvider 
    {

        public static SQLCommand INSTANCE {get; private set; }

        public static void AddInstance(string connectionString) {
            INSTANCE = new SQLCommand(connectionString);
        }
    
    }
}