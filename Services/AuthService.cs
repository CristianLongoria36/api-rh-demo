using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lib;

namespace Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext dbContext;
        public AuthService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
    }
}
