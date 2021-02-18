using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Marital
    {
        public Marital()
        {
            EmployeeData = new HashSet<EmployeeData>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeData> EmployeeData { get; set; }
    }
}
