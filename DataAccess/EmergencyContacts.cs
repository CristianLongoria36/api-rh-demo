using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class EmergencyContacts
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public long Fkemployee { get; set; }

        public virtual Employee FkemployeeNavigation { get; set; }
    }
}
