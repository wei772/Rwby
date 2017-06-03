using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rwby.DataAccess;
using Rwby.Users.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwby.Users.Service
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        protected UsersContext UserContext
        {
            get { return (UsersContext)DbContext; }
        }

        private readonly IMapper _mapper;

        public UserRepository(UsersContext userContext, IMapper mapper)
        {
            DbContext = userContext;
            _mapper = mapper;
        }


        public async Task<User> GetUser(string userId)
        {
            var user = await UserContext.Users
                    .AsNoTracking()
                    .SingleOrDefaultAsync(m => m.Id == userId);

            return _mapper.Map<User>(user);
        }

        public async Task<IList<User>> GetUsers()
        {
            var users = await UserContext.Users
                   .AsNoTracking()
                   .ToListAsync(); ;

            return _mapper.Map<IList<User>>(users);
        }
    }
}
