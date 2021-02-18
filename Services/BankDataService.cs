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
    public class BankDataService : IBankDataService
    {
        private readonly ApplicationDbContext dbContext;
        public BankDataService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public BankDataDTO GetByID(long employeeID)
        {
            BankDataDTO data = (from e in dbContext.Employee
                                join u in dbContext.User on e.Fkuser equals u.Id
                                join b in dbContext.BankData on e.Id equals b.Fkemployee
                                where u.Status.Equals(true) && e.Id.Equals(employeeID)
                                select new BankDataDTO
                                {
                                    Id = b.Id,
                                    Acount = b.AcountNumber,
                                    Clabe = b.InterbankClabe,
                                    Titular = b.TitularName,
                                    Bank = b.BankName
                                }).SingleOrDefault();
            return data;
        }
        public void Save(BankDataDTO data, long employeeID)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    QuerySave(data, employeeID);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Update(BankDataDTO data, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    BankData bankData = dbContext.BankData.SingleOrDefault(x => x.Id.Equals(id));
                    bankData.AcountNumber = AcountNumberExits(data.Acount) == true && bankData.AcountNumber != data.Acount ? bankData.AcountNumber : data.Acount;
                    bankData.BankName = data.Bank;
                    bankData.InterbankClabe = InterbankClabeExist(data.Clabe) == true && bankData.InterbankClabe != data.Clabe ? bankData.InterbankClabe : data.Clabe;
                    bankData.TitularName = data.Titular;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public void QuerySave(BankDataDTO data, long employeeID)
        {
            BankData bankData = new BankData()
            {
                InterbankClabe = data.Clabe,
                AcountNumber = data.Acount,
                BankName = data.Bank,
                TitularName = data.Titular,
                Fkemployee = employeeID
            };
            dbContext.BankData.Add(bankData);
            dbContext.SaveChanges();
        }
        public bool AcountNumberExits(int data)
        {
            return dbContext.BankData.Count(x => x.AcountNumber.Equals(data)) > 0;
        }
        public bool InterbankClabeExist(int data)
        {
            return dbContext.BankData.Count(x => x.InterbankClabe.Equals(data)) > 0;
        }
    }
}
