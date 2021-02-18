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
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext dbContext;
        public PositionService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void List(long DivisionID)
        {
        }
        public void Save(PositionDTO data, long divisionID)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (PositionExist(data.Name, divisionID))
                    {
                        throw new Exception("no found");
                    }
                    Position position = new Position()
                    {
                        Name = data.Name,
                        Fkdivision = divisionID
                    };
                    dbContext.Position.Add(position);
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
        public void Update(PositionDTO data, long divisionID, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    Position position = dbContext.Position.SingleOrDefault(x => x.Fkdivision.Equals(divisionID) && x.Id.Equals(id));
                    position.Name = data.Name != position.Name && PositionExist(data.Name, divisionID) ? position.Name : data.Name;
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
        public bool PositionExist(string name, long id)
        {
            return dbContext.Position.Count(x => x.Name.Equals(name) && x.Fkdivision.Equals(id)) > 0;
        }
    }
}
