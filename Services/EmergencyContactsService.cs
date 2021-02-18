using DataAccess;
using Lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace Services
{
    public class EmergencyContactsService
    { 
        private readonly ApplicationDbContext dbContext;
        public EmergencyContactsService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<EmergencyContactsDTO> Get(long id)
        {
            List<EmergencyContactsDTO> emergencyContacts = (from e in dbContext.Employee
                                                            join em in dbContext.EmergencyContacts on e.Id equals em.Fkemployee
                                                            join u in dbContext.User on e.Fkuser equals u.Id
                                                            where u.Status.Equals(true) && e.Id.Equals(id)
                                                            select new EmergencyContactsDTO
                                                            {
                                                                Id = em.Id,
                                                                Name = em.Name,
                                                                Phone = em.Phone
                                                            }).ToList();
            return emergencyContacts;
        }
        public void Save(List<EmergencyContactsDTO>data, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (EmergencyContactsDTO d in data)
                    {
                        QuerySave(d, id);
                    };
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
        public void Update(long id, EmergencyContactsDTO data)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    EmergencyContacts emergencyContacts = dbContext.EmergencyContacts.SingleOrDefault(x => x.Id.Equals(id));
                    emergencyContacts.Name = data.Name;
                    emergencyContacts.Phone = data.Phone;
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
                    EmergencyContacts emergencyContacts = dbContext.EmergencyContacts.SingleOrDefault(x => x.Id.Equals(id));
                    dbContext.EmergencyContacts.Remove(emergencyContacts);
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
        private void QuerySave(EmergencyContactsDTO data, long id)
        {
            EmergencyContacts emergencyContacts = new EmergencyContacts()
            {
                Name = data.Name,
                Phone = data.Phone,
                Fkemployee = id
            };
            dbContext.EmergencyContacts.Add(emergencyContacts);
            dbContext.SaveChanges();
        }
    }
}
