using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Conts
{
    /// <summary>
    /// Kullanıcı için generate edilecek olan tokenlar için kullanacağız.
    /// </summary>
    public static class UserTokenNames
    {
        public const string EmailVerification = "EmailVerificationToken";
        public const string PhoneVerification = "PhoneVerificationToken";
    }
}
