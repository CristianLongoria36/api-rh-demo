using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class PanelEmployee
    {
        private long id;
        private string name;
        private string email;
        private string division;
        private string position;
        private bool status;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Division { get => division; set => division = value; }
        public string Position { get => position; set => position = value; }
        public bool Status { get => status; set => status = value; }
    }
}
