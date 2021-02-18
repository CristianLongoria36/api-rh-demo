using System;
using System.Collections.Generic;
using System.Text;
using Lib;
using DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using Services.Contract;

namespace Services
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly ApplicationDbContext dbContext;
        public BeneficiaryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<BeneficiaryDTO> Get(long id)
        {
            List<BeneficiaryDTO> beneficiary = (from e in dbContext.Employee
                                                join b in dbContext.Beneficiary on e.Id equals b.Fkemployee
                                                join u in dbContext.User on e.Fkuser equals u.Id
                                                where u.Status.Equals(true) && e.Id.Equals(id)
                                                select new BeneficiaryDTO
                                                {
                                                    Id = b.Id,
                                                    Name = b.Name,
                                                    Type = b.Type
                                                }).ToList();
            return beneficiary;
        }
        public void Save(List<BeneficiaryDTO> data, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (BeneficiaryDTO d in data)
                    {
                        QuerySave(d, id);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Update(BeneficiaryDTO data, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    Beneficiary beneficiary = dbContext.Beneficiary.SingleOrDefault(x => x.Id.Equals(id));
                    data.Name = beneficiary.Name;
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
        public void Delete(long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    Beneficiary beneficiary = dbContext.Beneficiary.SingleOrDefault(x => x.Id.Equals(id));
                    dbContext.Beneficiary.Remove(beneficiary);
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
        public void QuerySave(BeneficiaryDTO data, long id)
        {
            Beneficiary beneficiary = new Beneficiary()
            {
                Name = data.Name,
                Type = data.Type,
                Fkemployee = id
            };
            dbContext.Beneficiary.Add(beneficiary);
            dbContext.SaveChanges();
        }
    }
}
