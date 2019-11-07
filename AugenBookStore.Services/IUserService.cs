using NetCoreTodoApi.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTodoApi.Services
{
    public interface IUserService
    {
        List<UserDto> Get();
        UserDto Get(int id);
        UserDto Get(string username, string password);
        UserDto Create(UserDto model);
    }
}
