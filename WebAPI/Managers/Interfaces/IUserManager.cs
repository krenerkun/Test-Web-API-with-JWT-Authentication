using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Model.Dto;

namespace WebAPI.Managers.Interfaces
{
    public interface IUserManager
    {
        IEnumerable<User> GetAllUsers();
        User Login(LoginDto loginDto);

        long Insert(User userModel);

        User Update(User userModel);

        void Delete(long id);

        User GetUserByEmail(string email);
    }
}
