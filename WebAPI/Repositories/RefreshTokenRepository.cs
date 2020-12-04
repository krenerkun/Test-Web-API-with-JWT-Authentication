using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Model;
using WebAPI.Repositories.Common;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokensRepository
    {
        public RefreshTokenRepository(RefreshTokenContext refreshTokenContext)
            :base(refreshTokenContext)
        {

        }
    }
}
