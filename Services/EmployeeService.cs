using DataAccess;
using Lib;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PaginationDTO<PanelEmployee> List(int page, int totalByPage, int status, string search)
        {
            IQueryable<PanelEmployee> query = QueryEmployeeList(status, search);
            PaginationDTO<PanelEmployee> employee = new PaginationDTO<PanelEmployee>(
                totalByPage,
                query.Count(),
                query.OrderBy(x => x.Email).Skip(page * totalByPage).Take(totalByPage).ToList()
            );
            return employee;
        }
        public void GetAll()
        {

        }
        public EmployeeDTO Get(long id)
        {
            EmployeeDTO employee = (from e in dbContext.Employee
                                        //join ed in dbContext.EmployeeData on e.Id equals ed.Fkemployee
                                    join u in dbContext.User on e.Fkuser equals u.Id
                                    where u.Status.Equals(true) && e.Id.Equals(id)
                                    select new EmployeeDTO
                                    {
                                        Salary = e.Salary,
                                        CodeEmployee = e.Code,
                                        Position = e.FkpositionNavigation.Name,
                                        Division = e.FkdivisionNavigation.Name,
                                        Currency = e.FkcurrencyNavigation.Name,
                                        EmployeeData = (from ed in dbContext.EmployeeData
                                                       where ed.Fkemployee.Equals(e.Id)
                                                       select new EmployeeDataDTO
                                                       {
                                                           Name = ed.Name,
                                                           Firts_surname = ed.FirtsSurname,
                                                           Second_surname = ed.SecondSurname,
                                                           Phone = ed.Phone,
                                                           Address = ed.Address,
                                                           DateBirth = ed.DateBirth.ToString()
                                                       }).SingleOrDefault()
                                        
                                    }).SingleOrDefault();
            return employee;
        }
        public void Save(EmployeeDTO data)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    Employee employee = new Employee()
                    {
                        Code = "wqqw",
                        Fkdivision = Convert.ToInt64(data.Division),
                        Fkcurrency = Convert.ToInt64(data.Currency),
                        Fkposition = Convert.ToInt64(data.Position),
                        Fkuser = 1,
                        Salary = data.Salary
                    };
                    dbContext.Employee.Add(employee);
                    dbContext.SaveChanges();
                    EmployeeData employeeData = new EmployeeData
                    {
                        Image = data.EmployeeData.Image,
                        Name = data.EmployeeData.Name,
                        FirtsSurname = data.EmployeeData.Firts_surname,
                        SecondSurname = data.EmployeeData.Second_surname,
                        Address = data.EmployeeData.Address,
                        Phone = data.EmployeeData.Phone,
                        DateBirth = DateTime.Parse(data.EmployeeData.DateBirth),
                        Fkemployee = 1,
                        Fkgender = Convert.ToInt64(data.EmployeeData.Gender),
                        Fkmarital = Convert.ToInt64(data.EmployeeData.Marital)
                    };
                    dbContext.EmployeeData.Add(employeeData);
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
        public void Update()
        {

        }
        public void UpdateEmployeeData()
        {

        }
        private IQueryable<PanelEmployee> QueryEmployeeList(int status, string search = null)
        {
            try
            {
                IQueryable<PanelEmployee> query = from u in dbContext.User
                                                  join e in dbContext.Employee on u.Id equals e.Fkuser
                                                  join ed in dbContext.EmployeeData on e.Id equals ed.Fkemployee
                                                  join d in dbContext.Division on e.Fkdivision equals d.Id
                                                  join p in dbContext.Position on e.Fkposition equals p.Id
                                                  select new PanelEmployee
                                                  {
                                                      Id = e.Id,
                                                      Name = ed.Name + " " + ed.FirtsSurname + " " + ed.SecondSurname,
                                                      Email = u.Email,
                                                      Division = d.Name,
                                                      Position = p.Name,
                                                      Status = u.Status
                                                  };
                if (status > 0)
                {
                    query.Where(x => x.Status.Equals(status == 1));
                }
                if (query.Count() > 0)
                {
                    if (!string.IsNullOrEmpty(search))
                    {
                        foreach (var item in search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Where(x => x.Email.Contains(item) || x.Name.Contains(item));
                            /*if (query.Count() == 0)
                            {
                                throw new Exception("no found");
                            }*/
                        }
                    }
                }
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }
        private void GenerateCode()
        {

        }
    }
}
