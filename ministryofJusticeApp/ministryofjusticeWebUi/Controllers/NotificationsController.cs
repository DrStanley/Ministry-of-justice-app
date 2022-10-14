﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ministryofjusticeWebUi.Interfaces;

namespace ministryofjusticeWebUi.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationsController()
        {
        }

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: Notifications
        public ActionResult Index()
        {
            var vm = _notificationService.GetNotifications();
            return View(vm);
        }

        public ActionResult ViewNotification(int id)
        {
            var notification = _notificationService.GetNotification(id);
            return RedirectToAction("CaseDetails", "Case", new {id = notification.CaseId});
        }

        public PartialViewResult RecentNotifications()
        {
            var vm = _notificationService.GetNotifications();
            return PartialView("_NotificationDropDown", vm);
        }
    }
}