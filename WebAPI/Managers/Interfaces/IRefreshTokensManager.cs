using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Managers.Interfaces
{
    public interface IRefreshTokensManager
    {
        RefreshToken GetToken(string refreshToken);
        RefreshToken UpdateToken(string refreshToken);
        RefreshToken AddToken(string userEmail);
    }
}
