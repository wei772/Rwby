using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Core
{
    public class OrganizationEntity 
    {

        public string OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IList<IOrganization> SubOrgs { get; set; }

        public IList<IUser> Users { get; set; }
    }
}
