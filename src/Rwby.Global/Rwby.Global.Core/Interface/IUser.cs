using System;

namespace Rwby.Global.Core
{
    public interface IUser
    {
        Guid UserId { get; set; }

        string UserName { get; set; }

    }
}
