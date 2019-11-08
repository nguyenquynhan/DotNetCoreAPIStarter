using System;

namespace NetCoreTodoApi.Repositories
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// SaveChanges
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
