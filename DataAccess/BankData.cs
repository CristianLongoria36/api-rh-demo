using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class BankData
    {
        public long Id { get; set; }
        public string BankName { get; set; }
        public int AcountNumber { get; set; }
        public int InterbankClabe { get; set; }
        public string TitularName { get; set; }
        public long Fkemployee { get; set; }
        public virtual Employee FkemployeeNavigation { get; set; }
    }
}
