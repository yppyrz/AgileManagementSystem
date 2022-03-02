using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// Entity içerisinde bir state değişimi oluştuğu durumlarda bu event başka bir entity'e haber verecek.
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// Gönderilen event ismini tutarız.
        /// </summary>
        public string Name { get; set; }
    }

    public class UserRegisteredEvent : IDomainEvent
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
    public class UserRegisterHandler : IDomainEventHandler<UserRegisteredEvent>
    {
        public void Handle(UserRegisteredEvent @event)
        {
            throw new NotImplementedException("IDomainEvent");
        }
    }
}
