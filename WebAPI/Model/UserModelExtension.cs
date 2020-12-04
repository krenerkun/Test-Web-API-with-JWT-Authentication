using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public static class UserModelExtension
    {
        public static IEnumerable<User> WithoutPassword(this IEnumerable<User> user) => user.Select(x => x.WithoutPassword());

        public static User WithoutPassword(this User user)
        {
            if (user == null) return null;

            user.Password = string.Empty;

            return user;
        }
    }
}
