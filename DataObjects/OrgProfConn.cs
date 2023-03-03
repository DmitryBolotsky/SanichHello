using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class OrgProfConn
    {
        public int OrgId { get; set; }
        public int ProfId { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ProfessionRef Prof { get; set; }
    }
}
