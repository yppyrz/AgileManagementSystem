using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// IDomainEvent'ten türetilmiş eventleri işleyen interface
    /// </summary>
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        void Handle(TDomainEvent @event);
    }
}
