using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class EmergencyContactsDTO
    {
        private long? id;
        private string name;
        private int phone;

        public long? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Phone { get => phone; set => phone = value; }
    }
}
