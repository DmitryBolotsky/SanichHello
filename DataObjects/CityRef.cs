using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class CityRef
    {
        public CityRef()
        {
            CitySourceConn = new HashSet<CitySourceConn>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<CitySourceConn> CitySourceConn { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
