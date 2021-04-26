using System;
using System.Collections.Generic;
using System.Data;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;

namespace ManagerApartmentProject.Repositories
{
    public interface INotificationRes
    {
        List<Notification> GetAll();
        /// <summary>
        /// Lấy về danh sách thông báo theo số trang.
        /// </summary>
        /// <param name="page">trang số</param>
        /// <returns>List<Notification></returns>
        List<Notification> GetByPage(int? page);
        List<Notification> GetByCreatorIdPage(int creatorId, int? page);
        Notification GetById(int id);
        bool Create(Notification model, int creatorId);
        bool EditById(int id, Notification model);
        bool DeleteById(int id);

        int GetPageCount(int creatorID);
    }
    public class NotificationRes : INotificationRes
    {
        private int _MAXROW;
        private Func<DataRow, Notification> _func;
        public NotificationRes(){
            _func = (DataRow row) => SQLCommand.Map<Notification>(row);
            _MAXROW = DataProvider.MAXROW;
        }

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


        public List<Notification> GetAll()
        {
            return DataProvider.GetListFrom<Notification>(
                "Notification_GetAll", 
                null,
                _func
            );
        }

        public List<Notification> GetByCreatorId(int creatorId)
        {
            return DataProvider.GetListFrom<Notification>(
                "Notification_GetByCreatorId",
                new object[] { creatorId },
                _func
            );
        }

        public List<Notification> GetByPage(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int start = _MAXROW * ((int)page - 1) + 1;
            int end = start + _MAXROW;

            return DataProvider.GetListFrom(
                "Notification_GetByRowNumber",
                new object[] { start, end },
                _func
            );
        }

        public List<Notification> GetByCreatorIdPage(int creatorId, int? page)
        {
            if (page == null)
            {
                page = 1;
            }

            int start = _MAXROW * ((int)page - 1) + 1;
            int end = start + _MAXROW;

            return DataProvider.GetListFrom<Notification>(
                "Notification_GetByCreatorIdRowNumber",
                new object[] { creatorId, start, end },
                _func
            );
        }

        public Notification GetById(int id)
        {
            return DataProvider.GetObjectByIdFrom<Notification>(
                "Notification_GetById",
                id,
                _func
            );
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