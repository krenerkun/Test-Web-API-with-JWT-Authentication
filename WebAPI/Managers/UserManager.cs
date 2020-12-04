using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Managers.Interfaces;
using WebAPI.Model;
using WebAPI.Model.Dto;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Managers
{
    public class UserManager : BaseManager, IUserManager
    {
        private readonly IUsersRepository _userRepo;

        public UserManager(IUnitOfWork unitOfWork, IUsersRepository userRepository)
            :base(unitOfWork)
        {
            this._userRepo = userRepository;
        }
        public void Delete(long id)
        {
            _userRepo.Delete(id);
            UnitOfWork.Commit();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.Get(user => user.DateDeleted == null).WithoutPassword();
        }

        public User GetUserByEmail(string email)
        {
            return _userRepo.Get(x => x.Email == email && x.DateDeleted == null).SingleOrDefault().WithoutPassword();
        }

        public long Insert(User userModel)
        {
            userModel.DateCreate = userModel.DateModified = DateTime.UtcNow;
            userModel.Status = StatusEnum.Pending;
            _userRepo.Insert(userModel);
            UnitOfWork.Commit();


            return userModel.ID;
        }

        public User Login(LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                return null;

            return _userRepo.Get(user => user.DateDeleted == null && user.Email == loginDto.Email && user.Password == loginDto.Password).SingleOrDefault().WithoutPassword();
        }

        public User Update(User userModel)
        {
            var targetUser = _userRepo.Get(x => x.DateDeleted == null && x.Email == userModel.Email).SingleOrDefault();

            if (targetUser != null)
            {
                userModel.DateModified = DateTime.UtcNow;
                userModel.Password = targetUser.Password;
                _userRepo.Update(userModel);
                UnitOfWork.Commit();
                return userModel.WithoutPassword();
            }
            return null;
        }
    }
}
