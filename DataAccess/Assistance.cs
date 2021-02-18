using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Assistance
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Comentary { get; set; }
        public long Fkemployee { get; set; }
        public long Status { get; set; }
        public virtual Employee FkemployeeNavigation { get; set; }
    }
}
