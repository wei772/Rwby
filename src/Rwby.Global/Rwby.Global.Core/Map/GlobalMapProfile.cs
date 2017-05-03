using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Core
{
    public class GlobalMapProfile : Profile
    {
        public GlobalMapProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserEntity, User>();
        }


    }
}
