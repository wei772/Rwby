﻿using System;
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

        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        //GET api/values/5
        [HttpGet("{id}")]

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
