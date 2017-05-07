using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rwby.Global.Core;
using Rwby.Global.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rwby.Global.Api
{

    [Authorize]
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        public Task<User> GetUser(string userId)
        {
            return _userService.GetUser(userId);
        }


        [HttpGet]
        public Task<IList<User>> GetUsers()
        {
            return _userService.GetUsers();
        }


    }
}
