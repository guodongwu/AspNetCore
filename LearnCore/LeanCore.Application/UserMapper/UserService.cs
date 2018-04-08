using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LearnCore.Core.Entities;
using LearnCore.Core.IRepositories;

namespace LearnCore.Application.UserMapper
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CheckUser(string userName, string password)
        {
            return _userRepository.CheckUser(userName, password);

        }

        public User GetUser(int id)
        {
            return _userRepository.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetAllListAsync();
        }

        public async Task<List<User>> GetUsers(Expression<Func<User, bool>> where)
        {
            return await _userRepository.GetAllListAsync(where);
        }
    }
}
