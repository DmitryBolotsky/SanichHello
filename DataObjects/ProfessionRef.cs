using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class ProfessionRef
    {
        public ProfessionRef()
        {
            OrgProfConn = new HashSet<OrgProfConn>();
        }

        public int Id { get; set; }
        public string ProfessionName { get; set; }

        public virtual ICollection<OrgProfConn> OrgProfConn { get; set; }
    }
}
