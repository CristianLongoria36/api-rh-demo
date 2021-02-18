using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public partial class Employee
    {
        public Employee()
        {
            Beneficiary = new HashSet<Beneficiary>();
            EmergencyContacts = new HashSet<EmergencyContacts>();
            RegistrationHistory = new HashSet<RegistrationHistory>();
            Assistance = new HashSet<Assistance>();
            VacationHistory = new HashSet<VacationHistory>();
        }
        public long Id { get; set; }
        public string Code { get; set; }
        public long Fkuser { get; set; }
        public long Fkdivision { get; set; }
        public long Fkposition { get; set; }
        public long Fkcurrency { get; set; }
        public decimal Salary { get; set; }
        public virtual Currency FkcurrencyNavigation { get; set; }
        public virtual Division FkdivisionNavigation { get; set; }
        public virtual Position FkpositionNavigation { get; set; }
        public virtual User FkuserNavigation { get; set; }
        public virtual BankData BankData { get; set; }
        public virtual EmployeeData EmployeeData { get; set; }
        public virtual ICollection<Beneficiary> Beneficiary { get; set; }
        public virtual ICollection<EmergencyContacts> EmergencyContacts { get; set; }
        public virtual ICollection<RegistrationHistory> RegistrationHistory { get; set; }
        public virtual ICollection<Assistance> Assistance { get; set; }
        public virtual ICollection<VacationHistory> VacationHistory { get; set; }
    }
}
