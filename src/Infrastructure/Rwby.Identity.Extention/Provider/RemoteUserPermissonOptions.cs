using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.AspNetCore.Identity
{
    public class RemoteUserPermissonOptions
    {
        public string ApiUrl { get; set; }

        //头痛?
        public string Authorization { get; set; }
    }
}
