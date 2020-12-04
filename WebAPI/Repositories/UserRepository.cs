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
    public class UserRepository : GenericRepository<User>, IUsersRepository
    {
        public UserRepository(RefreshTokenContext refreshTokenContext)
            :base(refreshTokenContext)
        {

        }
    }
}
