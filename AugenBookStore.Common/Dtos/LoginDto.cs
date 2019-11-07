using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTodoApi.Common.Dtos
{
    public class LoginDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
