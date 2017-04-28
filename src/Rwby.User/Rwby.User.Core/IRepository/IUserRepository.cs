using Rwby.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Core
{
    public interface IUserRepository : IRepository
    {
        User GetUser(Guid userId);

        IList<User> GetUsers();
    }
}
