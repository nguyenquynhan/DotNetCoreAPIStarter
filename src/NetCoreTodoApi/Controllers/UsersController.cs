using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCoreTodoApi.Common.Dtos;
using NetCoreTodoApi.Models;
using NetCoreTodoApi.Services;

namespace NetCoreTodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        public UsersController(ILogger<UsersController> logger
            , IOptions<AppSettings> appSettings
            , IUserService userService)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _userService = userService;
            GenerateDefaultData();
        }

        // GET: api/Users
        [HttpGet]
        public List<UserDto> Get()
        {
            return _userService.Get();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<UserDto> Get(int id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return NotFound("The user doesn't exist.");
            }

            user.Password = null;
            return user;
        }

        // POST: api/Users
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<ResponseLoginDto> Login(LoginDto login)
        {
            _logger.LogInformation("Post Login API", login);
            var admin = _userService.Get(login.Username, login.Password);
            if (admin != null)
            {
                admin.Password = null;
                var response = new ResponseLoginDto()
                {
                    User = admin
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, admin.Id.ToString()),
                        new Claim(ClaimTypes.GivenName, admin.FirstName),
                        new Claim(ClaimTypes.Surname, admin.LastName),
                        new Claim(ClaimTypes.NameIdentifier, admin.Username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                if (!string.IsNullOrEmpty(admin.Roles))
                {
                    List<string> roles = admin.Roles.Split(',').ToList();
                    foreach (string role in roles)
                    {
                        tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
                    }
                }
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Token = tokenHandler.WriteToken(token);

                return response;
            }

            return BadRequest(new { message = "Username or password is incorrect" });
        }

       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDto> Post(UserDto user)
        {
            return _userService.Create(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }



        private void GenerateDefaultData()
        {
            bool isNotExistAdmin = _userService.Get("Admin", "123") == null;
            if (isNotExistAdmin)
            {
                UserDto admin = new UserDto()
                {
                    Username = "Admin",
                    FirstName = "Supper",
                    LastName = "Admin",
                    Password = "123",
                    Roles = "Admin"
                };
                _userService.Create(admin);
            }

            bool isNotExistGuess = _userService.Get("Guess", "123") == null;
            if (isNotExistGuess)
            {
                UserDto guess = new UserDto()
                {
                    Username = "Guess",
                    FirstName = "Ms",
                    LastName = "Guess",
                    Password = "123"
                };
                _userService.Create(guess);
            }
        }
    }
}
