﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SilverScreen.Models.Tables;
using SilverScreen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverScreen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationManagementController : Controller
    {
        private IConfiguration Configuration;
        public NotificationManagementController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        [Route("GetNotifications")]
        [Authorize]
        public Notification[] GetNotifications(int userId) //should have authentication later (not responsible for that part)
        {
            NotificationService notificationService = new NotificationService(Configuration);
            var notifications = notificationService.GetAllNotificationsForUser(userId);
            return notifications; //It returns complex structure. Should I make another model for this?
        }

        [HttpGet]
        [Route("GetMovieNotifications")]
        [Authorize]
        public MovieNotification[] GetMovieNotifications(int userId) //should have authentication later (not responsible for that part)
        {
            NotificationService notificationService = new NotificationService(Configuration);
            var notifications = notificationService.GetAllMovieNotificationsForUser(userId);
            return notifications; //It returns complex structure. Should I make another model for this?
        }

        [HttpPost]
        [Route("SetFilmReleaseNotification")]
        [Authorize]
        public JsonResult SetFilmReleaseNotification(int userId, int movieID, bool status) //by status I mean delete if true, create if false 
        {
            NotificationService notificationService = new NotificationService(Configuration);
            try
            {
                switch (notificationService.SetFilmReleaseNotification(userId, movieID, status))
                {
                    case 0:
                        return Json(new { code = 0 });
                    case 404:
                        return Json(new { code = 404, errorMsg = "Notification not found!" });
                    case -1:
                        return Json(new { code = -1, errorMsg = "Notification was already set before!" });
                    default:
                        return Json(new { code = 500, errorMsg = "Something went wrong!" });
                }
            }
            catch(Exception)
            {
                return Json(new { code = 500, errorMsg = "Something went wrong!" });
            }
            
        }

        [HttpPost]
        [Route("RespondToFriendRequest")]
        [Authorize]
        public JsonResult RespondToFriendRequest(int notificationId)
        {
            NotificationService notificationService = new NotificationService(Configuration);
            switch (notificationService.RespondToFriendRequest(notificationId)) 
            {
                case 0:
                    return Json(new { code = 0 });
                case -1:
                    return Json(new { code = 404, errorMsg = "Notification not found!" });
                default:
                    return Json(new { code = 500, errorMsg = "Something went wrong!" });
            }
        }

        [HttpPost]
        [Route("RecommendMovieToAFriend")]
        [Authorize]
        public JsonResult RecommendMovieToAFriend(int userId, int friendId, int movieId, string message)
        {
            NotificationService notificationService = new NotificationService(Configuration);
            switch (notificationService.RecommendMovieToAFriend(userId, friendId, movieId, message))
            {
                case 0:
                    return Json(new { code = 0 });
                default:
                    return Json(new { code = 500, errorMsg = "Something went wrong!" });
            }
        }

        [HttpPatch]
        [Route("ToggleNotificationActivity")]
        [Authorize]
        public JsonResult ToggleNotificationActivity(int notificationId)
        {
            NotificationService notificationService = new NotificationService(Configuration);
            switch (notificationService.ToggleNotificationActivity(notificationId))
            {
                case 0:
                    return Json(new { code = 0 });
                case -1:
                    return Json(new { code = 404, errorMsg = "Notification not found!" });
                default:
                    return Json(new { code = 500, errorMsg = "Something went wrong!" });
            }
        }

        [HttpDelete]
        [Route("DeleteNotification")]
        [Authorize]
        public JsonResult DeleteNotifications(int notificationId)
        {
            NotificationService notificationService = new NotificationService(Configuration);
            switch (notificationService.DeleteNotification(notificationId))
            {
                case 0:
                    return Json(new { code = 0 });
                case -1:
                    return Json(new { code = 404, errorMsg = "Notification not found!" });
                default:
                    return Json(new { code = 500, errorMsg = "Something went wrong!" });
            }
        }
    }
}
