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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NetCoreTodoApi.Common.Utilities;

namespace NetCoreTodoApi.Services
{
    public class UserService: IUserService
    {
        private readonly ITodoUnitOfWork _uowTodo;
        private readonly IAutoMapperWrapper _mapper;
        private readonly IHashUtility _hashUtility;
        public UserService(ITodoUnitOfWork uowTodo
                            , IAutoMapperWrapper mapper
                            , IHashUtility hashUtility)
        {
            _uowTodo = uowTodo;
            _mapper = mapper;
            _hashUtility = hashUtility;
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
            string hashedPassword = _hashUtility.Encrypt(password);
            var user = _uowTodo.UserRepository.GetAll()
                            .FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);            
            return _mapper.Map<UserDto>(user);
        }
        public UserDto Create(UserDto model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = _hashUtility.Encrypt(model.Password),
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
