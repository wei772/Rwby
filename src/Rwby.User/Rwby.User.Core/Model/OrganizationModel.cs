using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Core.Model
{
    public class OrganizationModel: IOrganization
    {
        public string OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IList<IOrganization> SubOrgs { get; set; }

        public IList<IUser> Users { get; set; }
    }
}

