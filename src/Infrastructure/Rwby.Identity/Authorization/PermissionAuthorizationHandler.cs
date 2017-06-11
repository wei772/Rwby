using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Rwby.AspNetCore.Identity;
using System.Security.Claims;
using System;

namespace Rwby.AspNetCore.Authorization
{

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }

    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly ILogger _logger;
        private readonly PermissionManager<IdentityPermission> _permissionManager;

        public PermissionAuthorizationHandler(ILogger<PermissionAuthorizationHandler> logger, PermissionManager<IdentityPermission> permissionManager)
        {
            _logger = logger;
            _permissionManager = permissionManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            var currentUserPermissions = (await _permissionManager.GetUserPermissionAsync(context.User.GetUserId(), 0)).Select(o => o.Name);
            var authorized = requirement.RequiredPermissions.Any(rp => currentUserPermissions.Contains(rp));
            if (authorized) context.Succeed(requirement);
        }
    }
}