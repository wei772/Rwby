using Rwby.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Core
{
    public interface IUserRepository : IRepository
    {
        User GetUser(string userId);

        IList<User> GetUsers();
    }
}
