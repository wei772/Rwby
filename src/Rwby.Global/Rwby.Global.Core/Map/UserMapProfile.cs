using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Core
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserEntity, User>();
        }


    }
}
