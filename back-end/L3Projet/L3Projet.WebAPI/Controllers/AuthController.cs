using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService usersService;
        private IConfiguration _config;
        private List<BasicLogin> usersBDD;

        public AuthController(IUsersService usersService, IConfiguration config)
        {
            this._config = config;
            this.usersService = usersService;
            usersBDD = new();
            BasicLogin user1 = new()
            {
                uname = "user1",
                pass = BCrypt.Net.BCrypt.HashPassword("pass1")
            };
            usersBDD.Add(user1);
            BasicLogin user2 = new()
            {
                uname = "user2",
                pass = BCrypt.Net.BCrypt.HashPassword("pass2")
            };
            usersBDD.Add(user2);
        }

        [AllowAnonymous]
        [HttpPost("/login/basic")]
        public ActionResult BasicLogin([FromBody] BasicLogin? userLogin)
        {
            if (userLogin != null)
            {
                BasicLogin? userBdd = usersBDD.FirstOrDefault(user => user.uname == userLogin.uname);
                if (userBdd != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(userLogin.pass, userBdd.pass))
                    {
                        var tokenString = GenerateJSONWebToken(userLogin.uname);
                        return Ok(new { token = tokenString });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("/login/ms")]
        public ActionResult MSLogin([FromBody] MSLogin? msUser)
        {
            if (msUser != null)
            {
                var tokenString = GenerateJSONWebToken(msUser.first_name);
                return Ok(new { token = tokenString });
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("/signup")]
        public ActionResult<Signup> Signup([FromBody] Signup? newUser)
        {
            if (newUser != null)
            {
                newUser.password = BCrypt.Net.BCrypt.HashPassword(newUser.password);
                var countUsers = usersBDD.Count(x => x.uname == newUser.pseudo);
                if (countUsers > 0)
                {
                    return Conflict(newUser);
                }
                else
                {
                    return Ok(newUser);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("/test")]
        [Authorize]
        public ActionResult Test()
        {
            var currentUser = HttpContext.User.Identity.Name;
            return Ok(currentUser + " " + DateTime.Now);
        }

        private string GenerateJSONWebToken(string pseudo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, pseudo)/*,
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())*/
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

