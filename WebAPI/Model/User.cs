using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public enum StatusEnum
    {
        Pending = 0,
        Active = 1,
        Deleted = 2
    }
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public StatusEnum Status { get; set; }
        public string Token{ get; set; }
        public DateTime TokenExpiration { get; set; }
        public string TokenRefresh { get; set; }
    }
}
