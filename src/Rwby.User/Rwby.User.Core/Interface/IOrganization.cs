using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Core
{
    public interface IOrganization
    {
        string OrganizationId { get; set; }

        string OrganizationName { get; set; }

        IList<IOrganization> SubOrgs { get; set; }

        IList<IUser> Users { get; set; }

    }
}
