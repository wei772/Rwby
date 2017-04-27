using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rwby.User.Service;

namespace Rwby.User.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

  
        //GET api/values/5
        [HttpGet("GetUser/{id}")]
        public Core.User GetUser(string userId)
        {
            return _userService.GetUser(userId);
        }

        // GET api/values
        [HttpGet]
        public IList<Core.User> GetUsers()
        {
            return _userService.GetUsers();
        }


    }
}
