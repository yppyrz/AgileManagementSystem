using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Services
{
    public class ApplicationUserResult
    {
        /// <summary>
        /// İşlem başarılı mesajı
        /// </summary>
        public bool IsSucceeded { get; set; }
        
        /// <summary>
        /// User ile ilgili operasyonlar esnasında hata oluşursa, bu listeye ekleyip hataları son kullanıcıya göstereceğiz.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
    public interface IUserDomainService : IDomainService<ApplicationUser>
    {
        /// <summary>
        /// Sisteme yeni bir user kaydı açmamızı sağlayan servis.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ApplicationUserResult CreateUser(string email, string password);

        /// <summary>
        /// Gönderdiğimiz user'a göre profil bilgilerini günceller.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        ApplicationUserResult UpdateProfile(string firstName,string lastName,string middleName, ApplicationUser user);

        /// <summary>
        /// Gönderdiğimiz user'ın profil fotoğrafını günceller.
        /// </summary>
        /// <param name="profilePictureUrl"></param>    
        /// <param name="user"></param>
        /// <returns></returns>
        ApplicationUserResult UpdateProfilePicture(string profilePictureUrl,ApplicationUser user);

    }
}
