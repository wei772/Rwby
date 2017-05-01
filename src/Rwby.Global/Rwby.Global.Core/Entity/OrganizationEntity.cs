using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Core
{
    public class OrganizationEntity 
    {

        public Guid OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IList<IOrganization> SubOrgs { get; set; }

        public IList<IUser> Users { get; set; }
    }
}
