using System;
using System.Collections.Generic;

namespace Rwby.AspNetCore.Identity
{
    internal class PermissonEqualityComparer<TPermission, TKey> : IEqualityComparer<TPermission>
        where TKey : IEquatable<TKey>
        where TPermission : IdentityPermission<TKey>

    {
        public bool Equals(TPermission x, TPermission y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(TPermission obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}