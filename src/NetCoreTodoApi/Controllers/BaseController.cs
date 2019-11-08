using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreTodoApi.Common.Dtos;
using NetCoreTodoApi.Models;

namespace NetCoreTodoApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private UserDto _currentUser;
        public UserDto CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    var roles = this.User.Claims.Where(x => x.Type == ClaimTypes.Role)
                    .Select(x => x.Value).ToList();
                    _currentUser = new UserDto()
                    {
                        Id = int.Parse(this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value),
                        FirstName = this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName).Value,
                        LastName = this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname).Value,
                        Username = this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value,
                        Roles = string.Join(",", roles)
                    };
                }
                return _currentUser;
            }
        }
    }
}