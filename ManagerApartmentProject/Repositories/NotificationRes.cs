using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public class NotificationRes : INotificationRes
    {
        private int _MAXROW = 2;



        public bool Create(Notification model, int creatorID)
        {
            object[] values = {
                model.title,
                model.content,
                model.dateRelease,
                creatorID
            };

            return DataProvider.INSTANCE.ExecuteData("Notification_Add", values);
        }

        public bool DeleteById(int id)
        {
            return DataProvider.INSTANCE.ExecuteData("Notification_DeleteById", new object[] { id });
        }

        public bool EditById(int id, Notification model)
        {
            object[] values = {
                id,
                model.title,
                model.content,
                model.dateRelease,
            };

            return DataProvider.INSTANCE.ExecuteData("Notification_EditById", values);
        }


        private List<Notification> GetListFrom(string proceduceName, object[] values)
        {
            DataTable dt = DataProvider.INSTANCE.Select(proceduceName, values);
            List<Notification> lst = new List<Notification>();
            if (DataProvider.INSTANCE.errorCode == 0 && dt.Rows.Count > 0)
            {
                Notification tmp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tmp = SQLCommand.Map<Notification>(dt.Rows[i]);
                    lst.Add(tmp);
                }
            }

            return lst;
        }

        public List<Notification> GetAll()
        {
            return GetListFrom("Notification_GetAll", null);
        }

        public List<Notification> GetByCreatorId(int creatorId)
        {
            return GetListFrom("Notification_GetByCreatorId", new object[] { creatorId });
        }

        public List<Notification> GetByPage(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int start = _MAXROW * ((int)page - 1) + 1;
            int end = start + _MAXROW + 1;

            return GetListFrom("Notification_GetByRowNumber", new object[] { start, end });
        }

        public List<Notification> GetByCreatorIdPage(int creatorId, int? page)
        {
            if (page == null)
            {
                page = 1;
            }

            int start = _MAXROW * ((int)page - 1) + 1;
            int end = start + _MAXROW + 1;

            return GetListFrom(
                "Notification_GetByCreatorIdRowNumber",
                new object[] { creatorId, start, end }
            );
        }

        public Notification GetById(int id)
        {
            DataTable dt = DataProvider.INSTANCE.Select("Notification_GetById", new object[] { id });
            if (DataProvider.INSTANCE.errorCode == 0 && dt.Rows.Count > 0)
            {
                return SQLCommand.Map<Notification>(dt.Rows[0]); ;
            }

            return null;
        }

        public int GetPageCount(int creatorId)
        {
            DataTable dt = DataProvider.INSTANCE.Select("Notification_GetRowCount", new object[] { creatorId });
            if (DataProvider.INSTANCE.errorCode == 0 && dt.Rows.Count > 0)
            {
                double rowCount = Convert.ToDouble(dt.Rows[0]["count"]);
                double pageCount = rowCount / _MAXROW;

                return (int)Math.Ceiling(pageCount);
            }

            return 1;
        }
    }
}