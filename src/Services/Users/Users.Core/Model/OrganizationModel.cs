using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Users.Core.Model
{
    public class OrganizationModel
    {
        public Guid OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IList<OrganizationModel> SubOrgs { get; set; }

        public IList<UserModel> Users { get; set; }
    }
}

