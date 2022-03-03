using AgileManagementSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services
{
    public interface ITokenService
    {
        Task<TokenDto> GenerateToken(IEnumerable<Claim> Claims);
    }
}
