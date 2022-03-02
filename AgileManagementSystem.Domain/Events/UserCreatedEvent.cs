using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public string Name { get; set; } = "UserAccountCreated";
        public ApplicationUser Args { get; private set; }

        
        /// <summary>
        /// event içerisinde taşınacak olan değer. Taşınacak olan bu user bilgisine Args (Argümanlar) deriz.
        /// </summary>
        /// <param name="applicationUser"></param>
        public UserCreatedEvent(ApplicationUser applicationUser)
        {
            Args = applicationUser;
        }
    }
}
