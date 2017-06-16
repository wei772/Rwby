using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rwby.AspNetCore.Identity
{
    public interface IUserPermissonProvider
    {
        Task<IEnumerable<string>> GetUserPermissionAsync(string userId, long origin);
    }
}
