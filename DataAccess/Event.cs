using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Event
    {
        
        public long Id { get; set; }
        public string Title { get; set; }
        public string Messsage { get; set; }
        public DateTime Date { get; set; }
        public long? Fkdivision { get; set; }
        public virtual Division FkdivisionNavigation { get; set; }
    }
}
