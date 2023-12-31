﻿using EKLEXIA.ToastNotification.Notyf.Models;

namespace EKLEXIA.ToastNotification.Abstractions
{
    public interface INotyfService
    {
        void Success(string message, int? durationInSeconds = null);
        void Error(string message, int? durationInSeconds = null);
        void Information(string message, int? durationInSeconds = null);
        void Warning(string message, int? durationInSeconds = null);
        void Custom(string message, int? durationInSeconds = null, string backgroundColor = "black", string iconClassName = "home");
        IEnumerable<NotyfNotification> GetNotifications();
        IEnumerable<NotyfNotification> ReadAllNotifications();
        void RemoveAll();
    }
}
