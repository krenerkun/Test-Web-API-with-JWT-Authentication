using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Managers
{
    public class BaseManager
    {
        protected IUnitOfWork UnitOfWork { get; }

        public BaseManager(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
    }
}
