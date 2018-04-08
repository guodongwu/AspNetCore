using AutoMapper;
using LearnCore.Application.UserMapper;
using LearnCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCore.Application
{
   public class MapperManage
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserView>();
                cfg.CreateMap<UserView, User>();
                });
        }
    }
}
