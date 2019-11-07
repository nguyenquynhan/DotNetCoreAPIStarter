using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreTodoApi.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NetCoreTodoApi.Repositories.Entities.Todo;
using NetCoreTodoApi.Common.Dtos;

namespace NetCoreTodoApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
