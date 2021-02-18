using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class TypeBeneficiary
    {
        public TypeBeneficiary()
        {
            Beneficiary = new HashSet<Beneficiary>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Beneficiary> Beneficiary { get; set; }
    }
}
