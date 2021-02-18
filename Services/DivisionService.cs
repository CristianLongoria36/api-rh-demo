using DataAccess;
using Lib;
using Microsoft.EntityFrameworkCore.Storage;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class DivisionService : IDivisionService
    {
        private readonly ApplicationDbContext dbContext;
        public DivisionService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PaginationDTO<DivisionDTO> List(int page, int totalByPage, string search)
        {
            IQueryable<Division> query = QueryDivision();
            PaginationDTO<DivisionDTO> list = new PaginationDTO<DivisionDTO>(
                totalByPage,
                query.Count(),
                query.Select(x => new DivisionDTO { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).Skip(page * totalByPage).Take(totalByPage).ToList()
                );
            return list;
        }
        public void Save(DivisionDTO data)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    Division division = new Division()
                    {
                        Name = data.Name
                    };
                    dbContext.Division.Add(division);
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Update(DivisionDTO data, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    Division division = dbContext.Division.SingleOrDefault(x => x.Id.Equals(id));
                    division.Name = data.Name;
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        private IQueryable<Division> QueryDivision(string search = null)
        {
            IQueryable<Division> query = dbContext.Division;
            if (query.Count() > 0)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    foreach (var item in search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Where(x => x.Name.Contains(item));
                        if (query.Count() == 0)
                        {
                            throw new Exception("no found");
                        }
                    }
                }
            }
            return query;
        }
        public bool DivisionNameExist(string name)
        {
            return dbContext.Division.Count(x => x.Name.Equals(name)) > 0;
        }
        public bool DivisionIDExist(long id)
        {
            return dbContext.Division.Count(x => x.Id.Equals(id)) > 0;
        }
    }
}
