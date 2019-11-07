using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetCoreTodoApi.Repositories.Entities.Todo;

namespace NetCoreTodoApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _context;
        public UserRepository(TodoContext context)
        {
            _context = context;
        }
        public User Create(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
            return model;
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }
    }
}
