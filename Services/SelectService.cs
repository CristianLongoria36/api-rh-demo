using DataAccess;
using Lib;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class SelectService : ISelectService
    {
        private readonly ApplicationDbContext dbContext;
        public SelectService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<SelectDTO> SelectRole()
        {
            List<SelectDTO> select = dbContext.Role.Where(x => x.Status.Equals(true)).Select(x => new SelectDTO { Code = x.Id, Value = x.Name }).ToList();
            return select;
        }

        public List<SelectDTO> SelectMarital()
        {
            List<SelectDTO> select = dbContext.Marital.Select(x => new SelectDTO { Code = x.Id, Value = x.Name }).ToList();
            return select;
        }
        public List<SelectDTO> SelectDivision()
        {
            List<SelectDTO> select = dbContext.Division.Select(x => new SelectDTO { Code = x.Id, Value = x.Name }).ToList();
            return select;
        }
        public List<SelectDTO> SelectPosition(long id)
        {
            List<SelectDTO> select = (from d in dbContext.Division
                                      join p in dbContext.Position on d.Id equals p.Fkdivision
                                      where d.Id.Equals(id)
                                      select new SelectDTO
                                      {
                                          Code = p.Id,
                                          Value = p.Name
                                      }).ToList();
            return select;
        }
        public List<SelectDTO> SelectGender()
        {
            List<SelectDTO> select = dbContext.Gender.Select(x => new SelectDTO { Code = x.Id, Value = x.Name }).ToList();
            return select;
        }
        public List<SelectDTO> SelectCurrency()
        {
            List<SelectDTO> select = dbContext.Currency.Select(x => new SelectDTO { Code = x.Id, Value = x.Name }).ToList();
            return select;
        }
    }
}
