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
        private readonly IUtilisateursService usersService;
        private readonly IUtilisateursLocalService usersLocalService;
        private readonly IUtilisateursMicrosoftService usersMSService;
        private IConfiguration _config;

        public AuthController(IUtilisateursService usersService, IUtilisateursLocalService usersLocalService, IUtilisateursMicrosoftService usersMSService, IConfiguration config)
        {
            this._config = config;
            this.usersService = usersService;
            this.usersLocalService = usersLocalService;
            this.usersMSService = usersMSService;
        }

        [AllowAnonymous]
        [HttpPost("/login/basic")]
        public ActionResult BasicLogin([FromBody] BasicLogin? userLogin)
        {
            if (userLogin != null)
            {
                var ListUsers = usersService.GetAllUtilisateurs();
                Utilisateur? UserBDD = ListUsers.FirstOrDefault(user => (user.Pseudo == userLogin.uname) || (user.Email == userLogin.uname), null);
                if (UserBDD != null)
                {
                    var UserLocalBdd = UserBDD.ID_Utilisateur_Local;
                    if (BCrypt.Net.BCrypt.Verify(userLogin.pass, UserLocalBdd.Password))
                    {
                        var tokenString = GenerateJSONWebToken(UserBDD);
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
        public ActionResult MSLogin([FromBody] MSLogin? UserMSLogin)
        {
            if (UserMSLogin != null)
            {
                var userMS = usersMSService.GetAllUtilisateursMicrosoft().FirstOrDefault(user => user.Token == UserMSLogin.id);
                if (userMS != null)
                {
                    var UserLink = usersService.GetAllUtilisateurs().FirstOrDefault(user => user.ID_Utilisateur_Microsoft.ID_Microsoft == userMS.ID_Microsoft);
                    var tokenString = GenerateJSONWebToken(UserLink);
                    return Ok(new { token = tokenString });
                }
                else
                {
                    var NewUserMS = new Utilisateur();
                    NewUserMS.Pseudo = UserMSLogin.name;
                    NewUserMS.Email = UserMSLogin.email;
                    NewUserMS.ID_Utilisateur_Microsoft = new UtilisateurMicrosoft(UserMSLogin.id);
                    if (GenerateNewUser(NewUserMS))
                    {
                        var tokenString = GenerateJSONWebToken(NewUserMS);
                        return Ok(new { token = tokenString });
                    }
                    else
                    {
                        return Forbid();
                    }
                }
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
                var countUsers = usersService.GetAllUtilisateurs().Count(user => (user.Pseudo == newUser.pseudo) || (user.Email == newUser.email));
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

        private Boolean GenerateNewUser(Utilisateur newUser)
        {
            var user = usersService.AddUtilisateur(newUser);
            return user;
        }

        [HttpGet("/test")]
        [Authorize]
        public ActionResult Test()
        {
            var currentUser = HttpContext.User.Identity.Name;
            return Ok(currentUser + " " + DateTime.Now);
        }

        private string GenerateJSONWebToken(Utilisateur user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, user.Pseudo),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString("g")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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

