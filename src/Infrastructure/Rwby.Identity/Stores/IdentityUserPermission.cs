using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.AspNetCore.Identity
{

    public class IdentityUserPermission : IdentityUserPermission<string>
    {

    }

    public class IdentityUserPermission<TKey> where TKey : IEquatable<TKey>
    {
        public virtual int Id { get; set; }

        public virtual TKey UserId { get; set; }

        public virtual TKey PermissionId { get; set; }
    }
}
