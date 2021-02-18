using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class SelectDTO
    {
        private long code;
        private string value;

        public long Code { get => code; set => code = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
