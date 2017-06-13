using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rwby.AspNetCore.Mvc;
using Rwby.Users.Core;
using Rwby.Users.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rwby.Users.Api
{

    /// <summary>
    /// user controller
    /// </summary>
    [Authorize]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// get users
        /// </summary>
        /// <returns></returns>
        [RequiresPermission("GetUsers")]
        [HttpGet]
        [Route("[action]")]
        public Task<IList<User>> GetUsers()
        {
            return _userService.GetUsers();
        }

        /// <summary>
        /// get user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public Task<User> GetUser([FromQuery]string userId)
        {
            return _userService.GetUser(userId);
        }



    }
}
