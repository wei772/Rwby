using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rwby.User.Service;

namespace Rwby.User.Api.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

  
      
        [HttpGet]
        public Core.User GetUser(Guid userId)
        {
            return _userService.GetUser(userId);
        }

       
        [HttpGet]
        public IList<Core.User> GetUsers()
        {
            return _userService.GetUsers();
        }


    }
}
