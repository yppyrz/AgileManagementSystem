using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Handlers
{
    public class UserCreatedNotifyHandler : IDomainEventHandler<UserCreatedEvent>
    {
        public void Handle(UserCreatedEvent @event)
        {
            // yazılacak.
        }
    }
}
