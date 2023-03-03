using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class User
    {
        public User()
        {
            Organization = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public string Nikname { get; set; }
        public string Mail { get; set; }
        public string Picture { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }

        public virtual CityRef City { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
    }
}
