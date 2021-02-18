using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Vacation
    {
        public Vacation()
        {
            VacationHistory = new HashSet<VacationHistory>();
        }
        public long Id { get; set; }
        public int Days { get; set; }
        public int AccumulatedDays { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
        public long Fkregistration { get; set; }
        public virtual RegistrationHistory FkregistrationNavigation { get; set; }
        public virtual ICollection<VacationHistory> VacationHistory { get; set; }
    }
}
