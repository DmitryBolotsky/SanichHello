using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class Master
    {
        public Master()
        {
            CitySourceConn = new HashSet<CitySourceConn>();
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Experience { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<CitySourceConn> CitySourceConn { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
