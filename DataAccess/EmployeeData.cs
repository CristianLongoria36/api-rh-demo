using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class EmployeeData
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string FirtsSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Address { get; set; }
        public DateTime DateBirth { get; set; }
        public long Fkmarital { get; set; }
        public long Fkgender { get; set; }
        public long Fkemployee { get; set; }
        public int Phone { get; set; }
        public long? PlaceBirth { get; set; }
        public long? PlaceRecidence { get; set; }

        public virtual Employee FkemployeeNavigation { get; set; }
        public virtual Gender FkgenderNavigation { get; set; }
        public virtual Marital FkmaritalNavigation { get; set; }
    }
}
