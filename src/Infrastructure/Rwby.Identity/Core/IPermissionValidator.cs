using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Rwby.AspNetCore.Identity
{
    public interface IPermissionValidator<TPermission> where TPermission : class
    {
   
            Task<IdentityResult> ValidateAsync(PermissionManager<TPermission> manager, TPermission permission);
        
    }
}