using LearnCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnCore.Application.UserMapper
{
   public interface IUserService
    {
        User CheckUser(string userName, string password);
        User GetUser(int id);
        Task<List<User>> GetUsers();
        Task<List<User>> GetUsers(Expression<Func<User, bool>> where);
    }
}
