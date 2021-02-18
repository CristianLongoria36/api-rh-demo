using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
