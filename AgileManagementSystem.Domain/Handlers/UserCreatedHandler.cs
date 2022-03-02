using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Core.Notification;
using AgileManagementSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Handlers
{
    /// <summary>
    /// DomainEvent.Raise olduğunda event fırlatılacak. UserCreatedHandler fırlatılan bu eventi yakalayacak. Event ile alakalı işlemleri yapacak.
    /// </summary>
    public class UserCreatedHandler : IDomainEventHandler<UserCreatedEvent>
    {
        private readonly IEmailService _emailService;
        public UserCreatedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Handle(UserCreatedEvent @event)
        {
            string registerUri = "https://localhost:5001/account/confirm?verificationCode=";


            string htmlString = $"<p>Hesabınızı aktive etmek için aşağıdaki linkte tıklayınız<a href={registerUri}>Aktive Et<a/></p>";

            //_logService.Log("User Account Successfully Created", LogLevels.Information);

            _emailService.SendSingleEmailAsync(to: @event.Args.Email, subject: "Hesap Aktivasyonu", htmlString);
        }
    }
}
