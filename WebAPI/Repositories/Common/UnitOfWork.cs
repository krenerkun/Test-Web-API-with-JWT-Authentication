using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private RefreshTokenContext _refreshTokenContext;
        private bool disposed = false;

        public UnitOfWork(RefreshTokenContext refreshTokenContext)
        {
            _refreshTokenContext = refreshTokenContext;
        }

        public void Commit()
        {
            _refreshTokenContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposed)
        {
            if (!disposed)
            {
                if (!isDisposed)
                {
                    _refreshTokenContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
