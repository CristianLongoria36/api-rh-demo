using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Division
    {
        public Division()
        {
            Employee = new HashSet<Employee>();
            Position = new HashSet<Position>();
            Event = new HashSet<Event>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Position> Position { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
