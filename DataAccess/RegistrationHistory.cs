using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class RegistrationHistory
    {
        public RegistrationHistory()
        {
            Vacation = new HashSet<Vacation>();
        }
        public long Id { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateFinish { get; set; }
        public long Fkemployee { get; set; }
        public virtual Employee FkemployeeNavigation { get; set; }
        public virtual ICollection<Vacation> Vacation { get; set; }
    }
}
