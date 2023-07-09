

using EKLEXIA.ToastNotification.Abstractions;

namespace EKLEXIA.ToastNotification.Containers
{
    public interface IMessageContainerFactory
    {
        IToastNotificationContainer<TMessage> Create<TMessage>() where TMessage : class;
    }
}
