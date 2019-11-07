using NetCoreTodoApi.Repositories;
using NetCoreTodoApi.Repositories.Entities.Todo;

namespace NetCoreTodoApi.Repositories
{
    /// <summary>
    /// IUserManagementUnitOfWork
    /// </summary>
    public interface ITodoUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DbContext
        /// </summary>
        TodoContext DbContext { get; }

        /// <summary>
        /// UserRepository
        /// </summary>
        IRepository<User> UserRepository { get; set; }
    }
}
