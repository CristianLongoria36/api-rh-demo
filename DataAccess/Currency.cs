using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Currency
    {
        public Currency()
        {
            Employee = new HashSet<Employee>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
