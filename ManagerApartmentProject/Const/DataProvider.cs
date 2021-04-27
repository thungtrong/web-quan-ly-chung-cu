using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Models;
namespace ManagerApartmentProject.Const
{
    public static class DataProvider
    {
        public static SQLCommand INSTANCE { get; private set; }
        public static int MAXROW { get; internal set; }

        public static void AddInstance(string connectionString)
        {
            INSTANCE = new SQLCommand(connectionString);
            MAXROW = 10;
        }

        /// <summary>
        /// Get List of model T from database by proceduce has name is proceduceName
        /// </summary>
        /// <param name="proceduceName">Ten Proceduce</param>
        /// <param name="values">Tham so truyen vao Proceduce</param>
        /// <param name="func">Func thuc hien Map DataRow thanh kieu du lieu T</param>
        /// <typeparam name="T">Kieu du lieu can lay</typeparam>
        /// <returns>List of model T</returns>
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

        /// <summary>
        /// Get instance class T from database by proceduceName
        /// </summary>
        /// <param name="proceduceName">Name of Proceduce</param>
        /// <param name="id">ID</param>
        /// <param name="func">Func mapping DataRow to T</param>
        /// <typeparam name="T">Type of instance</typeparam>
        /// <returns>Object Type T</returns>
        public static T GetObjectByIdFrom<T>(string proceduceName, int id, Func<DataRow, T> func)
        {
            if (id > 0)
            {
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

        public static PersonModel GetPersonByValuesFrom(
            string proceduceName,
            object[] values)
        {
            
            DataTable dt = DataProvider.INSTANCE
                                        .Select(
                                            proceduceName,
                                            values);

            if (DataProvider.INSTANCE.errorCode == 0 && dt.Rows.Count > 0)
            {
                return SQLCommand.Map<PersonModel>(dt.Rows[0]);
            }
            return default(PersonModel);
        }
    }
}