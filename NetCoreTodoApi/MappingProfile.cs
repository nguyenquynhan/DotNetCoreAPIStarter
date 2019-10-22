using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreTodoApi.Models;
using NetCoreTodoApi.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace NetCoreTodoApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
