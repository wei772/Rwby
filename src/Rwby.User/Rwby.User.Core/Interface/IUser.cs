using System;

namespace Rwby.User.Core
{
    public interface IUser
    {
        Guid UserId { get; set; }

        string UserName { get; set; }

    }
}
