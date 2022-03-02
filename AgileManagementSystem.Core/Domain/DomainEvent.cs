using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// Bu sınıf IOC ile singleton bir instance olarak tanımlanacaktır. Uygulama çalıştırıldığında tek bir instance ile uygulama genelinde çalıştıracağız.
    /// IOC üzerinden tanımlanmış tüm handler'lara dispatcher üzerindeki Dispatch metodu ile erişip tetikleme sağlayacağız.
    /// Fakat bu işlemler Infrastructure katmanında tanımlanacaktır.
    /// </summary>
    public static class DomainEvent
    {
        public static IDomainEventDispatcher Dispatcher { get; set; }

        public static void Raise<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent
        {
            Dispatcher.Dispatch(@event);
        }
    }
}
