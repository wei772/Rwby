using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rwby.DataAccess;
using Rwby.Global.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
