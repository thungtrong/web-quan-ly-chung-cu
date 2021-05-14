using Microsoft.AspNetCore.Mvc;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace ManagerApartmentProject.Controllers
{
    [Authorize]
    // [Authorize(Policy = "AllowedAll")]
    public class NotificationController : Controller
    {
        private readonly INotificationRes _notificationRes;
        private readonly ILogger<NotificationController> _logger;
        // private readonly int _MAXROW;
        public NotificationController(INotificationRes notificationRes, ILogger<NotificationController> logger)
        {
            _notificationRes = notificationRes;
            _logger = logger;

            // _MAXROW = 10;
        }

        [HttpGet("[controller]/[action]/{pageAll?}/{pageMy?}")]
        public async Task<IActionResult> Index(int? pageAll, int? pageMy)
        {
            var _creator = int.Parse(User.FindFirst("Id").Value);

            if (pageAll == null)
            {
                pageAll = 1;
            }
            if (pageMy == null)
            {
                pageMy = 1;
            }

            var taskNotifyAll = Task<List<Notification>>.Run(
                () => _notificationRes.GetByPage(pageAll)
            );
            var taskPageCountAll = Task<int>.Run(() => _notificationRes.GetPageCount(0));
            
           
            List<Notification> lstNotifyMy = new List<Notification>();
            int pageCountMy = 0;

            if (User.IsInRole("Admin") || User.IsInRole("SuperAdmin"))
            {    
                var taskNotify2 = Task<List<Notification>>.Run(
                    () => _notificationRes.GetByCreatorIdPage(_creator, pageMy)
                );
                var taskPageCount2 = Task<int>.Run(() => _notificationRes.GetPageCount(_creator));
                
                lstNotifyMy = await taskNotify2;
                pageCountMy = await taskPageCount2;
            }

            var lstNotifyAll = await taskNotifyAll;
            int pageCountAll = await taskPageCountAll;

            NotificationViewModel model = new NotificationViewModel
            {
                allNotifications = lstNotifyAll,
                allNotificationsStart = (int)pageAll,
                allNotificationsEnd = Math.Min((int)pageAll + 5, pageCountAll),

                myNotifications = lstNotifyMy,
                myNotificationsStart = (int)pageMy,
                myNotificationsEnd = Math.Min((int)pageMy + 5, pageCountMy)
            };
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await Task<Notification>.Run(() => _notificationRes.GetById(id));
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new Notification { dateRelease = DateTime.Now });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notification model)
        {
            var _creator = int.Parse(User.FindFirst("Id").Value);

            bool result = await Task<bool>.Run(() => _notificationRes.Create(model, _creator));
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int Id)
        {
            var _creator = int.Parse(User.FindFirst("Id").Value);

            var model = await Task<Notification>.Run(() => _notificationRes.GetById(Id));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Notification model)
        {
            if (id == model.ID)
            {
                bool result = await Task<bool>.Run(() => _notificationRes.EditById(id, model));
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            _logger.LogInformation($"{model.ToString()}, id = {id}");

            return View(model);
        }

        [Authorize(Policy = "SuperAdmin")]
        [Route("api/Notification/Delete/{page}")]
        public async Task<string> Delete(int id)
        {
            bool result = await Task<bool>.Run(() => _notificationRes.DeleteById(id));
            string message = "Error";
            if (result)
            {
                message = "Success";
            }
            return JsonSerializer.Serialize(new
            {
                result = result,
                message = message
            });
        }

        [Route("Notification/api/GetPageAll/{page}")]
        public async Task<string> GetPageAll(int page)
        {

            if (page <= 0)
            {
                return JsonSerializer.Serialize(new
                {
                    status = 0,
                    message = "Page must be greater than zero"
                });
            }

            List<Notification> lst = await Task.Run(
                () => _notificationRes.GetByPage(page)
            );

            int pageCount = await Task<int>.Run(
                () => _notificationRes.GetPageCount(0)
            );

            string json = JsonSerializer.Serialize(new
            {
                status = 1,
                notifications = lst,
                pagination = new
                {
                    start = page,
                    end = Math.Min(pageCount, page + 5)
                }
            });

            return json;
        }

        [Route("Notification/api/GetPageMy/{page}")]
        public async Task<string> GetPageMy(int page)
        {
            var _creator = int.Parse(User.FindFirst("Id").Value);

            if (page <= 0)
            {
                return JsonSerializer.Serialize(new
                {
                    status = 0,
                    message = "Page must be greater than zero"
                });
            }

            List<Notification> lst = await Task.Run(
                () => _notificationRes.GetByCreatorIdPage(_creator, page)
            );

            int pageCount = await Task<int>.Run(
                () => _notificationRes.GetPageCount(_creator)
            );

            string json = JsonSerializer.Serialize(new
            {
                status = 1,
                notifications = lst,
                pagination = new
                {
                    start = page,
                    end = Math.Min(pageCount, page + 5)
                }
            });
            return json;
        }
    }
}