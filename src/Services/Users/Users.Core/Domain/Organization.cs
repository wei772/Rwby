using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Users.Core
{
    public class Organization
    {

        public string OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IList<Organization> SubOrgs { get; set; }

        public IList<User> Users { get; set; }
    }
}
