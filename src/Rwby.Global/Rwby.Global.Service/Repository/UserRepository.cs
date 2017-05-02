using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rwby.DataAccess;
using Rwby.Global.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwby.Global.Service
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        protected GlobalContext UserContext
        {
            get { return (GlobalContext)DbContext; }
        }

        private readonly IMapper _mapper;

        public UserRepository(GlobalContext userContext, IMapper mapper)
        {
            DbContext = userContext;
            _mapper = mapper;
        }


        public Core.User GetUser(string userId)
        {
            var user = UserContext.Users
                    .AsNoTracking()
                    .SingleOrDefault(m => m.Id == userId);

            return _mapper.Map<Core.User>(user);
        }

        public IList<Core.User> GetUsers()
        {
            var users = UserContext.Users
                   .AsNoTracking()
                   .ToList();

            return _mapper.Map<IList<Core.User>>(users);
        }
    }
}
