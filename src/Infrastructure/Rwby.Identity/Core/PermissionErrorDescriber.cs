using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.AspNetCore.Identity
{
    public class PermissionErrorDescriber
    {
        /// <summary>
        /// Returns the default <see cref="IdentityError"/>.
        /// </summary>
        /// <returns>The default <see cref="IdentityError"/>.</returns>
        public virtual IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = "DefaultError"
            };
        }
    }
}
