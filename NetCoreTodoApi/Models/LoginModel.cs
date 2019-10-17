using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTodoApi.Models
{
    public class LoginModel
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
    }
}
