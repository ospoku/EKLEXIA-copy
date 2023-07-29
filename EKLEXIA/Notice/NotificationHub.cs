using Microsoft.AspNetCore.SignalR;

namespace EKLEXIA.Notice
{
    public class NotificationHub:Hub
    {
        public string Text { get; set; } = "";
        public bool IsRead { get; set; } = false;
    }
}
