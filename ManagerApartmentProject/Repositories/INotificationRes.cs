using System.Collections.Generic;
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
}