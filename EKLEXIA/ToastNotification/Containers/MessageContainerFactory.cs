﻿
using EKLEXIA.ToastNotification.Abstractions;
using EKLEXIA.ToastNotification.Helpers;


namespace EKLEXIA.ToastNotification.Containers
{
    internal class MessageContainerFactory : IMessageContainerFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataService _tempDataWrapper;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataService tempDataWrapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
        }

        public IToastNotificationContainer<TMessage> Create<TMessage>()
            where TMessage : class
        {
            if (_httpContextAccessor.HttpContext.Request.IsNotyfAjaxRequest())
            {
                return new InMemoryNotificationContainer<TMessage>();
            }
            else
            {
                return new TempDataToastNotificationContainer<TMessage>(_tempDataWrapper);
            }
        }
    }
}