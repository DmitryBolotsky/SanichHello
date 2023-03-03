using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class ServiceRef
    {
        public ServiceRef()
        {
            OrgServConn = new HashSet<OrgServConn>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<OrgServConn> OrgServConn { get; set; }
    }
}
