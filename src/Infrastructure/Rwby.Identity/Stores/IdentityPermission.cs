using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Rwby.AspNetCore.Identity
{
    public class IdentityPermission: IdentityPermission<string>
    {

    }

    public class IdentityPermission<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string NormalizedName { get; set; }

        public virtual string Description { get; set; }

        public virtual string ConcurrencyStamp { get; set; }

        /// <summary>
        /// while Origin=0 IsGlobal
        /// </summary>
        public virtual long Origin { get; set; }


    }


}