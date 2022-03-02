using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Models
{
    public class ApplicationUser:Entity
    {
        public bool EmailVerified { get; private set; }

        /* Required Properties */

        /// <summary>
        /// Oturum açan kullanıcının kullanıcı adı. Unique bir değeri olmalıdır.
        /// </summary>
        public string UserName { get; private set; }
        
        /// <summary>
        /// Oturum açan kullanıcının email adresi. Unique bir değer olmalıdır.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Şifrelenmiş password değeri. Kullanıcı şifreleri Hash algoritması ile şifrelenir.
        /// </summary>
        public string PasswordHash { get; private set; }

        /* Optional Properties */

        /// <summary>
        /// Kullanıcının gerçek ismi. Profil oluşturmak için zorunlu değildir.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Kullanıcının gerçek soyismi. Profil oluşturmak için zorunlu değildir. 
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Varsa kullanıcının ikinci ismi.  Profil oluşturmak için zorunlu değildir.
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// Kullanıcının Profil fotoğrafının url adresi. Profil oluşturmak için zorunlu değildir.
        /// </summary>
        public string ProfilePictureUrl { get; private set; }

        public ApplicationUser(string email)
        {
            Id = Guid.NewGuid().ToString();
            SetEmail(email);
            SetUserName(email);
        }

        /// <summary>
        /// Username alanı boş bırakılırsa, kullanıcının email adresi username alanına tanımlanır.
        /// </summary>
        /// <param name="userName"></param>
        public void SetUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                this.UserName = this.Email;
            }
            this.UserName = userName.Trim();
        }

        /// <summary>
        /// Kullanıcının Email bilgisini değiştirmek için kullanırız.
        /// </summary>
        /// <param name="email"></param>
        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("E-posta alanı boş geçilemez.");
            }
            this.Email = email.Trim();
        }

        /// <summary>
        /// Kullanıcıya Hash'lenmiş bir parola tanımlamak için kullanırız.
        /// </summary>
        /// <param name="passwordHash"></param>
        public void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new Exception("Parola alanı boş geçilemez.");
            }
            this.PasswordHash = passwordHash.Trim();
        }

        /// <summary>
        /// Kullanıcıya ait profil özelliklerini güncellemek için kullanırız.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        public void SetProfileInfo(string firstName,string lastName,string middleName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception("FirstName alanı boş geçilemez.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception("LastName alanı boş geçilemez.");
            }

            this.FirstName = firstName.Trim();
            this.LastName = lastName.Trim().ToUpper();
            this.MiddleName = middleName.Trim();
        }

        /// <summary>
        /// Kullanıcının profil fotoğrafını güncellemek için kullanırız.
        /// </summary>
        /// <param name="profilePictureUrl"></param>
        public void SetProfilePicture(string profilePictureUrl)
        {
            if (string.IsNullOrEmpty(profilePictureUrl))
            {
                throw new Exception("Profil fotoğrafı boş geçilemez.");
            }
            this.ProfilePictureUrl = profilePictureUrl.Trim();
        }

        public void SetVerifyEmail()
        {
            this.EmailVerified = true;
        }
    }
}
