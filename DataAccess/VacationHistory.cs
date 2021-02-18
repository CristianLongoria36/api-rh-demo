using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class VacationHistory
    {
        public long Id { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Finish { get; set; }
        public int Days { get; set; }
        public int AccumulatedDays { get; set; }
        public string Comentary { get; set; }
        public string EmployeeFirm { get; set; }
        public string ManagerFirm { get; set; }
        public int State { get; set; }
        public long? FkmanagerApprove { get; set; }
        public long Fkvacation { get; set; }
        public virtual Employee FkmanagerApproveNavigation { get; set; }
        public virtual Vacation FkvacationNavigation { get; set; }
    }
}
