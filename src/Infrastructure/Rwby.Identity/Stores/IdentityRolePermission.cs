using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.AspNetCore.Identity
{

    public class IdentityRolePermission : IdentityRolePermission<string>
    {

    }

    public class IdentityRolePermission<TKey> where TKey : IEquatable<TKey>
    {

        public virtual TKey RoleId { get; set; }

        public virtual TKey PermissionId { get; set; }
    }
}
