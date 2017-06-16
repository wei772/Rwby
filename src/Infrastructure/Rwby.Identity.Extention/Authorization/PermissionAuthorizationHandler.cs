using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Rwby.AspNetCore.Identity;
using System.Security.Claims;
using System;
using IdentityModel;

namespace Rwby.AspNetCore.Authorization
{

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(JwtClaimTypes.Subject)?.Value;
        }
    }

    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly ILogger _logger;
        private readonly IUserPermissonProvider _permissionProvider;

        public PermissionAuthorizationHandler(ILogger<PermissionAuthorizationHandler> logger, IUserPermissonProvider permissionProvider)
        {
            _logger = logger;
            _permissionProvider = permissionProvider;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            var userId = context.User.GetUserId();
            var currentUserPermissions = await _permissionProvider.GetUserPermissionAsync(userId, 0);
            var authorized = requirement.RequiredPermissions.Any(rp => currentUserPermissions.Contains(rp));
            if (authorized) context.Succeed(requirement);
        }
    }
}