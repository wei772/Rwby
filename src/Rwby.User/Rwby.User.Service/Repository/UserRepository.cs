using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rwby.DataAccess;
using Rwby.User.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwby.User.Service
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        public UserContext UserContext
        {
            get { return (UserContext)DbContext; }
        }

        public UserRepository(UserContext userContext)
        {
            DbContext = userContext;
        }
 

        public Core.User GetUser(Guid userId)
        {
            var user = UserContext.Users
                    .AsNoTracking()
                    .SingleOrDefault(m => m.UserId == userId);

            return Mapper.Map<Core.User>(user);
        }

        public IList<Core.User> GetUsers()
        {
            var users = UserContext.Users
                   .AsNoTracking()
                   .ToList();

            return Mapper.Map<IList<Core.User>>(users);
        }
    }
}
