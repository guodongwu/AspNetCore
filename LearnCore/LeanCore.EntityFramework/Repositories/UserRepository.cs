using LearnCore.Core.Entities;
using LearnCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnCore.EntityFramework.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        public User CheckUser(string userName, string password)
        {
            return _dbContext.Set<User>().FirstOrDefault(p=>p.UserName==userName && p.Password==password);
        }

        public User GetUser(int id)
        {
            return _dbContext.Set<User>().FirstOrDefault(p => p.Id == id);
        }

        public List<User> GetUsers()
        {
            return _dbContext.Set<User>().ToList();
        }

        public List<User> GetUsers(Expression<Func<User, bool>> where)
        {
            return _dbContext.Set<User>().Where(where).ToList();
        }

 
    }
}
