using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Core
{
    public class User : IUser
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

    }
}
