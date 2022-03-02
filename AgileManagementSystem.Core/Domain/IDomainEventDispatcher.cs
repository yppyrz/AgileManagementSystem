using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// IDomainEvent olan bir Event fırlatıldığında, fırlatılan event'in handler'a iletilmesinden sorumlu olan alt yapıdır.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        void Dispatch<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent;
    }
}
