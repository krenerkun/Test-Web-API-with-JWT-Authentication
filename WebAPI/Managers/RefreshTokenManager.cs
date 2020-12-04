using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Managers.Interfaces;
using WebAPI.Model;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Managers
{
    public class RefreshTokenManager : BaseManager, IRefreshTokensManager
    {
        public readonly IRefreshTokensRepository _refreshTokensRepository;
        public RefreshTokenManager(IUnitOfWork unitOfWork, IRefreshTokensRepository refreshTokensRepository)
            :base(unitOfWork)
        {
            _refreshTokensRepository = refreshTokensRepository;
        }

        public RefreshToken GetToken(string refreshToken)
        {
            return _refreshTokensRepository.Get(token => token.RefreshTokenString == refreshToken).SingleOrDefault();
        }

        public RefreshToken AddToken(string userEmail)
        {
            var refreshTokenModel = new RefreshToken
            {
                Email = userEmail,
                RefreshTokenString = Guid.NewGuid().ToString(),
                DateModified = DateTime.UtcNow,
                DateCreate = DateTime.UtcNow
            };

            _refreshTokensRepository.Insert(refreshTokenModel);
            UnitOfWork.Commit();
            return refreshTokenModel;
        }

        public RefreshToken UpdateToken(string refreshToken)
        {
            var _refreshToken = GetToken(refreshToken);

            if (_refreshToken !=null)
            {
                _refreshToken.DateModified = DateTime.UtcNow;
                _refreshToken.RefreshTokenString = Guid.NewGuid().ToString();
                _refreshTokensRepository.Update(_refreshToken);
                UnitOfWork.Commit();


                return _refreshToken;
            }

            return null;
        }
    }
}
