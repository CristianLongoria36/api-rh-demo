using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class EmployeeDataDTO
    {
        private long id;
        private string image;
        private string name;
        private string firts_surname;
        private string second_surname;
        private string address;
        private string dateBirth;
        private string marital;
        private string gender;
        private int phone;

        public long Id { get => id; set => id = value; }
        public string Image { get => image; set => image = value; }
        public string Name { get => name; set => name = value; }
        public string Firts_surname { get => firts_surname; set => firts_surname = value; }
        public string Second_surname { get => second_surname; set => second_surname = value; }
        public string Address { get => address; set => address = value; }
        public string DateBirth { get => dateBirth; set => dateBirth = value; }
        public string Marital { get => marital; set => marital = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Phone { get => phone; set => phone = value; }
    }
}
