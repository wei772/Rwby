using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rwby.AspNetCore.Identity;
using Rwby.Identity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rwby.Identity.Controllers

{
    [Authorize]
    [Route("[controller]")]
    public class PermissionController : Controller
    {
        private PermissionManager<AppPermission> _permissionManager;

        public PermissionController(PermissionManager<AppPermission> permissionManager)
        {
            _permissionManager = permissionManager;
        }

        [Route("[action]")]
        public async Task<IActionResult> GetUserPermission(string userId, long origin)
        {
            var pers = await _permissionManager.GetUserPermissionAsync(userId, origin);
            return Ok(JsonConvert.SerializeObject(pers));
        }

    }
}
