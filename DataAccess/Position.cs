using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public long Fkdivision { get; set; }
        public virtual Division FkdivisionNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
