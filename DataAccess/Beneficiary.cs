using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Beneficiary
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Fkemployee { get; set; }
        public long Fktype { get; set; }
        public virtual TypeBeneficiary FkbeneficiaryNavigation { get; set; }
        public virtual Employee FkemployeeNavigation { get; set; }
    }
}
