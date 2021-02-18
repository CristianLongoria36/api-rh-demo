using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLogin { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
        public long Fkrole { get; set; }
        public virtual Role FkroleNavigation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
