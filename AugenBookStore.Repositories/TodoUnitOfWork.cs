using System;
using System.Collections.Generic;
using AutoMapper;
using NetCoreTodoApi.Repositories;
using NetCoreTodoApi.Repositories.Entities.Todo;

namespace NetCoreTodoApi.Repositories
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public class TodoUnitOfWork : ITodoUnitOfWork, IDisposable
    {
        private readonly TodoContext _context;

        public TodoUnitOfWork(TodoContext context,
                            IRepository<User> userRepository)
        {
            _context = context;
            UserRepository = userRepository;
        }

        public TodoContext DbContext
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// NodeRepository
        /// </summary>
        public IRepository<User> UserRepository { get; set; }
        /// <summary>
        /// SaveChanges
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

    }
}
