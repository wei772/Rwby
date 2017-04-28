using Rwby.User.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Core.User GetUser(Guid userId)
        {
            return _userRepository.GetUser(userId);
        }


        public IList<Core.User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
