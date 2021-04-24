using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Models;
namespace ManagerApartmentProject.Const
{
    public class DataProvider 
    {
        public static SQLCommand INSTANCE {get; private set; }
        public static int MAXROW { get; internal set; }

        public static void AddInstance(string connectionString) {
            INSTANCE = new SQLCommand(connectionString);
            MAXROW = 10;
        }

        public static List<T> GetListFrom<T>(string proceduceName, object[] values, Func<DataRow, T> func)
        {
            DataTable dt = DataProvider.INSTANCE.Select(proceduceName, values);
            List<T> lst = new List<T>();
            if (DataProvider.INSTANCE.errorCode == 0 && dt.Rows.Count > 0)
            {
                T tmp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tmp = func(dt.Rows[i]);
                    lst.Add(tmp);
                }
            }
            return lst;
        }

        public static T GetObjectByIdFrom<T>(string proceduceName, int id, Func<DataRow, T> func){
            if (id > 0){
                DataTable dt = DataProvider.INSTANCE
                                            .Select(
                                                proceduceName,
                                                new object[] { id });

                if (DataProvider.INSTANCE.errorCode == 0 && dt.Rows.Count > 0)
                {
                    return func(dt.Rows[0]);
                }
            }

            return default(T);
        }
    }
}