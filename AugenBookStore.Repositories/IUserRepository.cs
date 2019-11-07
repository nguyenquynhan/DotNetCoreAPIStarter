using NetCoreTodoApi.Repositories.Entities.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreTodoApi.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User Get(int id);
        User Create(User model);
    }
}
