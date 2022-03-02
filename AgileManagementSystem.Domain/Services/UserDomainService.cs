using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Core.Security;
using AgileManagementSystem.Domain.Events;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserDomainService(IApplicationUserRepository applicationUserRepository, IPasswordHasher passwordHasher)
        {
            _applicationUserRepository = applicationUserRepository;
            _passwordHasher = passwordHasher;
        }

        public ApplicationUserResult CreateUser(string email, string password)
        {
            var result = new ApplicationUserResult() { IsSucceeded = true };
            
            // email Unique mi ?
            var emailExists = _applicationUserRepository.GetQuery().FirstOrDefault(x => x.Email == email) == null ? false : true;

            if (emailExists)
            {
                result.Errors.Add("Aynı hesap sistemde mevcut");
            }
            else
            {
                var user = new ApplicationUser(email);

                // Parola hash işlemi.
                var hashedPassword = _passwordHasher.HashPassword(password);
                user.SetPasswordHash(hashedPassword);

                _applicationUserRepository.Add(user);
                _applicationUserRepository.Save();

                var dbUser = _applicationUserRepository.Find(user.Id);

                if (dbUser == null)
                {
                    result.Errors.Add("Hesap oluşturulamadı");
                }
                else
                {
                    DomainEvent.Raise(new UserCreatedEvent(user));
                }
            }
            result.IsSucceeded = result.Errors.Count() > 0 ? false : true;
            return result;
        }

        public ApplicationUserResult UpdateProfile(string firstName, string lastName, string middleName, ApplicationUser user)
        {
            user.SetProfileInfo(firstName, lastName, middleName);
            // Logic yazılabilir.
            _applicationUserRepository.Update(user);
            _applicationUserRepository.Save();

            return new ApplicationUserResult
            {
                IsSucceeded = true
            };
        }

        public ApplicationUserResult UpdateProfilePicture(string profilePictureUrl, ApplicationUser user)
        {
            user.SetProfilePicture(profilePictureUrl);
            // Logic yazılabilir.
            _applicationUserRepository.Update(user);
            _applicationUserRepository.Save();

            return new ApplicationUserResult
            {
                IsSucceeded = true
            };
        }
    }
}
