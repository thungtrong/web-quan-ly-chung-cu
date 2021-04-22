using System.Collections.Generic;

namespace ManagerApartmentProject.Models
{
    public class NotificationViewModel 
    {
        public List<Notification> allNotifications { get; set; }
        public List<Notification> myNotifications { get; set; }

        public int allNotificationsStart { get; set; }
        public int myNotificationsStart { get; set; }
        public int allNotificationsEnd { get; set; }
        public int myNotificationsEnd { get; set; }
    }
}