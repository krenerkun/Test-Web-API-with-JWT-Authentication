using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Repositories.Common;

namespace WebAPI.Repositories.Interfaces
{
    public interface IRefreshTokensRepository : IGenericRepository<RefreshToken>
    {
    }
}
