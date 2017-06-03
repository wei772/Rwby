using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Users.Core
{
    public class UsersMapProfile : Profile
    {
        public UsersMapProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserEntity, User>();

        }


    }
}
