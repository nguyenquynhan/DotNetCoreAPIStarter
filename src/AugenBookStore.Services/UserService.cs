using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using NetCoreTodoApi.Repositories;
using AugenBookStore.Common;
using NetCoreTodoApi.Repositories.Entities.Todo;
using NetCoreTodoApi.Common.Dtos;
using AugenBookStore.Common.Wrappers;

namespace NetCoreTodoApi.Services
{
    public class UserService: IUserService
    {
        private readonly ITodoUnitOfWork _uowTodo;
        private readonly IAutoMapperWrapper _mapper;
        public UserService(ITodoUnitOfWork uowTodo, IAutoMapperWrapper mapper)
        {
            _uowTodo = uowTodo;
            _mapper = mapper;
        }

        public List<UserDto> Get()
        {
            return _uowTodo.UserRepository.GetAll().ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToList();
        }

        public UserDto Get(int id)
        {
            var user = _uowTodo.UserRepository.Get(id);
            return _mapper.Map<UserDto>(user);
        }
        public UserDto Get(string username, string password)
        {
            var user = _uowTodo.UserRepository.GetAll()
                            .FirstOrDefault(x => x.Username == username && x.Password == password);            
            return _mapper.Map<UserDto>(user);
        }
        public UserDto Create(UserDto model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Roles = model.Roles
            };
            _uowTodo.UserRepository.Create(user);
            _uowTodo.SaveChanges();
            model.Id = user.Id;
            return model;
        }
    }
}
