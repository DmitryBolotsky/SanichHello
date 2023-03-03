using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class CitySourceConn
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int IdCity { get; set; }
        public int SourceType { get; set; }

        public virtual CityRef IdCityNavigation { get; set; }
        public virtual Master Source { get; set; }
        public virtual Organization SourceNavigation { get; set; }
    }
}
