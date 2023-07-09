﻿using EKLEXIA.ToastNotification.Abstractions;
using EKLEXIA.ToastNotification.Enums;

namespace EKLEXIA.ToastNotification.Notyf.Models
{
    public class NotyfNotification : Notification
    {
        public NotyfNotification(ToastNotificationType type, string message, int? durationInSeconds) : base(type, message, durationInSeconds)
        {
           
        }
        public string Icon { get; set; }
    }
}
