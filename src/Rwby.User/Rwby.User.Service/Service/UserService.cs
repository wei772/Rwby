using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Service
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public Core.User GetUser(string userId)
        {
            return _userRepository.GetUser(userId);
        }


        public IList<Core.User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
