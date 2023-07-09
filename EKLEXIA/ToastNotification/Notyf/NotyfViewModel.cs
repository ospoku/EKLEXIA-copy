using EKLEXIA.ToastNotification.Notyf.Models;

namespace EKLEXIA.ToastNotification.Notyf
{
    public class NotyfViewModel
    {
        public string Configuration { get; set; }
        public IEnumerable<NotyfNotification> Notifications { get; set; }
    }
}
