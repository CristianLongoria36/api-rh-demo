using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class PositionDTO
    {
        private long id;
        private string name;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
