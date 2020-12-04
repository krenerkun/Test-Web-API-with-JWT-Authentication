using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class RefreshToken : BaseModel
    {
        public string Email { get; set; }
        public string RefreshTokenString { get; set; }
    }
}
