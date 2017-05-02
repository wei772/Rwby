using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Core
{
    public class User : IdentityUser, IUser
    {
        public string UserId { get; set; }
    }
}
