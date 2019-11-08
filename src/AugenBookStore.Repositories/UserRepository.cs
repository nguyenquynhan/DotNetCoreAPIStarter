using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetCoreTodoApi.Repositories.Entities.Todo;

namespace NetCoreTodoApi.Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository(TodoContext dbContext)
            : base(dbContext)
        { }
    }
}
