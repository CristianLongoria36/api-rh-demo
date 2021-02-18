using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class EmployeeDTO
    {
        private long id;
        private string codeEmployee;
        private string division;
        private string position;
        private decimal salary;
        private string currency;
        private EmployeeDataDTO employeeData;

        public long Id { get => id; set => id = value; }
        public string CodeEmployee { get => codeEmployee; set => codeEmployee = value; }
        public string Division { get => division; set => division = value; }
        public string Position { get => position; set => position = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public string Currency { get => currency; set => currency = value; }
        public EmployeeDataDTO EmployeeData { get => employeeData; set => employeeData = value; }
    }
}
