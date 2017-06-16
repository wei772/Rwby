using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Rwby.AspNetCore.Identity;

namespace Rwby.AspNetCore.Authorization
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> RequiredPermissions { get; }

        public PermissionAuthorizationRequirement(IEnumerable<string> requiredPermissions)
        {
            RequiredPermissions = requiredPermissions;
        }
    }
}