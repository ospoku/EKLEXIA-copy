using Microsoft.AspNetCore.SignalR;

namespace EKLEXIA.Notice
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string Message)
        {
            await Clients.All.SendAsync("ReceiveNotification", Message);

        }
    }
}
