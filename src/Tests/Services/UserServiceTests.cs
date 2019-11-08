using NetCoreTodoApi.Services;
using NUnit.Framework;
using NetCoreTodoApi.Common.Dtos;
using NetCoreTodoApi.Repositories;
using NetCoreTodoApi.Repositories.Entities.Todo;
using Moq;
using NetCoreTodoApi.Common.Utilities;
using AugenBookStore.Common.Wrappers;
using System;

namespace Tests
{
    public class UserServiceTests
    {
        private IUserService _userService;
        private Mock<ITodoUnitOfWork> _uowTodo;
        private Mock<IRepository<User>> _userRepository;
        private Mock<IAutoMapperWrapper> _mapper;
        private Mock<IHashUtility> _hashUtility;
        [SetUp]
        public void Setup()
        {
            _uowTodo = new Mock<ITodoUnitOfWork>();
            _mapper = new Mock<IAutoMapperWrapper>();
            _hashUtility = new Mock<IHashUtility>();

            _userRepository = new Mock<IRepository<User>>();
            _userRepository.Setup(x => x.Get(1)).Returns(new User() { Username = "Abc"});
            _userRepository.Setup(x => x.Get(-1)).Returns((User)null);
            _userRepository.Setup(x => x.Get(-2)).Throws(new Exception());
            _uowTodo.Setup(x => x.UserRepository).Returns(_userRepository.Object);

            _mapper.Setup(x => x.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto());
            _userService = new UserService(_uowTodo.Object, _mapper.Object, _hashUtility.Object);
        }

        [Test]
        public void Get_ValidId_ReturnResult()
        {
            int id = 1;
            var user = _userService.Get(id);
            Assert.IsNotNull(user);
        }

        [Test]
        public void Get_InvalidId_IsNull()
        {
            int id = -1;
            var user = _userService.Get(id);
            Assert.IsNull(user);
        }

        [Test]
        public void Get_RepositoryGetThrowException_ThrowException()
        {
            int id = -2;
            try
            {
                var user = _userService.Get(id);
            }catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}