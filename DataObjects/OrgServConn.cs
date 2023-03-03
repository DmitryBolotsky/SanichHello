using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class OrgServConn
    {
        public int OrgId { get; set; }
        public int ServId { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ServiceRef Serv { get; set; }
    }
}
