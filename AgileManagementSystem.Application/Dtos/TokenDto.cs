using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Dtos
{
    public static class TokenExpireDateHelper
    {
        public static int GetExpireDateSeconds = 3600;
    }

    /// <summary>
    /// Son kullanıcıya gidecek response
    /// </summary>
    public  class TokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireDateSeconds { get; set; } = TokenExpireDateHelper.GetExpireDateSeconds;
        public string TokenType { get; set; } = "Bearer";
    }
}
