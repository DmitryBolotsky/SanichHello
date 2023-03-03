using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class Organization
    {
        public Organization()
        {
            CitySourceConn = new HashSet<CitySourceConn>();
            Comments = new HashSet<Comments>();
            OrgProfConn = new HashSet<OrgProfConn>();
            OrgServConn = new HashSet<OrgServConn>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ogrn { get; set; }
        public string Inn { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime CreateFrom { get; set; }
        public int UserId { get; set; }
        public string Picture { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CitySourceConn> CitySourceConn { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<OrgProfConn> OrgProfConn { get; set; }
        public virtual ICollection<OrgServConn> OrgServConn { get; set; }
    }
}
