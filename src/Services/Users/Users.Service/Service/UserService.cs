using Rwby.Users.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rwby.Users.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUser(string userId)
        {
            return _userRepository.GetUser(userId);
        }


        public Task<IList<User>> GetUsers()
        {
            return _userRepository.GetUsers();
        }
}
}
