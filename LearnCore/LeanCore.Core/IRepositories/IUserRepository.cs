using LearnCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnCore.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User CheckUser(string userName, string password);
        User GetUser(int id);
        List<User> GetUsers();
        List<User> GetUsers(Expression<Func<User, bool>> where);
       
    }
}
