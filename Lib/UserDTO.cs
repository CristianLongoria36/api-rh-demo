using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class UserDTO
    {
        private long id;
        private string email;
        private string password;
        private string role;
        private bool status;

        public long Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public bool Status { get => status; set => status = value; }
    }
}
