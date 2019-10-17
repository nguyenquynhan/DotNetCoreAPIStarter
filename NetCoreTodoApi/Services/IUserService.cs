using NetCoreTodoApi.Entities;
using NetCoreTodoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTodoApi.Services
{
    public interface IUserService
    {
        List<UserModel> Get();
        UserModel Get(int id);
        UserModel Get(string username, string password);
        UserModel Create(UserModel model);
    }
}
