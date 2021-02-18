using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class BeneficiaryDTO
    {
        private long? id;
        private string name;
        private string type;

        public long? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
