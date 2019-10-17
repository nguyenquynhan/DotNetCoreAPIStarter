using NetCoreTodoApi.Entities;
using NetCoreTodoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTodoApi.Services
{
    public class UserService: IUserService
    {
        private readonly TodoContext _context;
        public UserService(TodoContext context)
        {
            _context = context;
        }

        public List<UserModel> Get()
        {
            return _context.Users.Select(x=> new UserModel() {
                Id = x.Id,
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Password = x.Password,
                Roles = x.Roles
            }).ToList();
        }

        public UserModel Get(int id)
        {
            return _context.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Password = x.Password,
                Roles = x.Roles
            }).FirstOrDefault(x=>x.Id == id);
        }
        public UserModel Get(string username, string password)
        {
            return _context.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Password = x.Password,
                Roles = x.Roles
            }).FirstOrDefault(x => x.Username == username && x.Password == password);
        }
        public UserModel Create(UserModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Roles = model.Roles
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            model.Id = user.Id;
            return model;
        }
    }
}
