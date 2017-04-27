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

        public override void Init()
        {
            //DbContext = serviceProvider.GetService<UserContext>();
        }

        public Core.User GetUser(string userId)
        {
            var user = UserContext.Users
                    .AsNoTracking()
                    .SingleOrDefault(m => m.UserId == userId);

            return Mapper.Map<Core.User>(user);
        }

        public IList<Core.User> GetUsers()
        {
            var users = UserContext.Users
                   .AsNoTracking();

            return Mapper.Map<IList<Core.User>>(users);
        }
    }
}
