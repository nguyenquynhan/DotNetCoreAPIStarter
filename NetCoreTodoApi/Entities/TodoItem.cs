using System;
using System.Collections.Generic;

namespace NetCoreTodoApi.Entities
{
    public partial class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
