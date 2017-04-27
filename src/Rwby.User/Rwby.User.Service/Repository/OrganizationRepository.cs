using Rwby.DataAccess;
using Rwby.User.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Service
{
    public class OrganizationRepository : RepositoryBase, IUserRepository
    {
        public Core.User GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<Core.User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
