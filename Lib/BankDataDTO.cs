using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class BankDataDTO
    {
        private long id;
        private string bank;
        private string titular;
        private int acount;
        private int clabe;

        public long Id { get => id; set => id = value; }
        public string Bank { get => bank; set => bank = value; }
        public string Titular { get => titular; set => titular = value; }
        public int Acount { get => acount; set => acount = value; }
        public int Clabe { get => clabe; set => clabe = value; }
    }
}
