using DataAccess;
using Lib;
using Microsoft.EntityFrameworkCore.Storage;
using Services.Contract;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PaginationDTO<UserDTO> List(int page, int totalByPage, bool status, string search = null)
        {
            IQueryable<UserDTO> query = (from u in dbContext.User
                                         join r in dbContext.Role on u.Fkrole equals r.Id
                                         where u.Status.Equals(status)
                                         select new UserDTO
                                         {
                                             Email = u.Email,
                                             Password = "",
                                             Role = r.Name,
                                             Id = u.Id,
                                             Status = u.Status
                                         });
            if (query.Count() > 0)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    foreach (var item in search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Where(x => x.Email.Contains(item));
                        if (query.Count() == 0)
                        {
                            throw new Exception("no found");
                        }
                    }
                }
            }
            PaginationDTO<UserDTO> user = new PaginationDTO<UserDTO>(
                totalByPage,
                query.Count(),
                query.OrderBy(x => x.Email).Skip(page * totalByPage).Take(totalByPage).ToList()
            );
            return user;
        }
        public void Save(UserDTO data)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (UserExist(data.Email))
                    {
                        throw new Exception("exits");
                    }
                    User user = new User()
                    {
                        Email = data.Email,
                        Password = Encrypt.EncriptPassword(data.Password),
                        Token = Token(),
                        Fkrole = Convert.ToInt64(data.Role)
                    };
                    dbContext.User.Add(user);
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
        public void Update(UserDTO data, long id)
        {
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (UserExist(data.Email))
                    {
                        throw new Exception("exits");
                    }
                    User user = dbContext.User.SingleOrDefault(x => x.Status.Equals(true) && x.Id.Equals(id));
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
        private bool UserExist(string email)
        {
            return dbContext.User.Count(x => x.Email.Equals(email)) > 0;
        }
        public long QueryUserSave(UserDTO data)
        {
            if (UserExist(data.Email))
            {
                throw new Exception("exits");
            }
            User user = new User()
            {
                Email = data.Email,
                Password = Encrypt.EncriptPassword(data.Password),
                Token = Guid.NewGuid().ToString("N"),
                Fkrole = Convert.ToInt64(data.Role)
            };
            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return user.Id;
        }
        private string Token()
        {
            string token;
            while (true)
            {
                token = "";
                token = Guid.NewGuid().ToString("N");
                bool exist = dbContext.User.Count(x => x.Token.Equals(token)) > 0;
                if (exist == false)
                {
                    break;
                }
            }
            return token;
        }
    }
}
