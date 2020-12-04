using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Managers.Interfaces;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        public readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsers() => Ok(_userManager.GetAllUsers());

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User userModel) => Ok(_userManager.Insert(userModel));
    }
}
