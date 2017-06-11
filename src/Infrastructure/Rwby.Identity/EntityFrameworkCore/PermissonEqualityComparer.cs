using System;
using System.Collections.Generic;

namespace Rwby.AspNetCore.Identity
{
    internal class PermissonEqualityComparer<TPermission> : IEqualityComparer<TPermission>
    {
        public bool Equals(TPermission x, TPermission y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(TPermission obj)
        {
            throw new NotImplementedException();
        }
    }
}