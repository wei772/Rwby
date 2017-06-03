using Rwby.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rwby.Users.Core
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetUser(string userId);

        Task<IList<User>> GetUsers();
    }
}
