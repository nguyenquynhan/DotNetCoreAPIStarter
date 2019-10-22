using AutoMapper;
using NetCoreTodoApi.Entities;
using NetCoreTodoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace NetCoreTodoApi.Services
{
    public class UserService: IUserService
    {
        private readonly TodoContext _context;
        private readonly IAutoMapperWrapper _mapper;
        public UserService(TodoContext context, IAutoMapperWrapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserModel> Get()
        {
            return _context.Users.ProjectTo<UserModel>(_mapper.ConfigurationProvider).ToList();
        }

        public UserModel Get(int id)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Id == id);
            return _mapper.Map<UserModel>(user);
        }
        public UserModel Get(string username, string password)
        {
            var user = _context.Users
                            .FirstOrDefault(x => x.Username == username && x.Password == password);            
            return _mapper.Map<UserModel>(user);
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
