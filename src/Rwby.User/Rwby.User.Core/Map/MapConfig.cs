using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Core
{
    public class MapConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserEntity, User>();
                cfg.CreateMap<User, UserModel>();
            });
        }
    }
}
