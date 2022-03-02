using AgileManagementSystem.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Infrastructure.Events
{
    public class NetCoreEventDispatcher : IDomainEventDispatcher
    {
        /// <summary>
        /// AddServices olarak startup'a tanımlanmış olan bir Handler'a _serviceProvider.GetService ile erişmemiz gerekir ki doğru handler'ın handle metodunu tetikleyelim.
        /// Sistem buna runtime'da karar verecektir.
        /// Locator Pattern.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        public NetCoreEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent
        {
            if (_serviceProvider != null)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    foreach (var handler in scope.ServiceProvider.GetServices<IDomainEventHandler<TDomainEvent>>())
                    {
                        handler.Handle(@event);
                    }
                }
            }
        }
    }
}
