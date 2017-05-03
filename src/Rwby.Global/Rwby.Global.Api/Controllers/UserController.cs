﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rwby.Global.Service;
using Rwby.Global.Core;

namespace Rwby.Global.Api
{
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
