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
        private readonly IUtilisateursMicrosoftService usersMSService;
        private readonly IMondesService worldsService;
        private IConfiguration _config;

        public AuthController(IUtilisateursService usersService, IUtilisateursMicrosoftService usersMSService, IMondesService worldsService, IConfiguration config)
        {
            this._config = config;
            this.usersService = usersService;
            this.usersMSService = usersMSService;
            this.worldsService = worldsService;
        }

        [AllowAnonymous]
        [HttpPost("/login/basic")]
        public ActionResult BasicLogin([FromBody] BasicLogin? userLogin)
        {
            if (userLogin != null)
            {
                var ListUsers = usersService.GetAllUtilisateurs();
                Utilisateur? UserBDD = ListUsers.FirstOrDefault(user => (user.Pseudo == userLogin.uname) || (user.Email == userLogin.uname));
                if (UserBDD != null)
                {
                    var UserLocalBdd = UserBDD.ID_Utilisateur_Local;
                    if (UserLocalBdd != null)
                    {
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
                var userMS = usersMSService.GetAllUtilisateursMicrosoft().FirstOrDefault(user => user.Token == UserMSLogin.ID);
                if (userMS != null)
                {
                    var UserLink = usersService.GetAllUtilisateurs().FirstOrDefault(user => user.ID_Utilisateur_Microsoft.ID_Microsoft == userMS.ID_Microsoft);
                    var tokenString = GenerateJSONWebToken(UserLink);
                    return Ok(new { token = tokenString });
                }
                else
                {
                    var ListUsers = usersService.GetAllUtilisateurs();
                    Utilisateur? NewUserMS = ListUsers.FirstOrDefault(user => user.Email == UserMSLogin.Email, new Utilisateur(UserMSLogin.displayName, UserMSLogin.lastName, UserMSLogin.firstName, UserMSLogin.Email));
                    NewUserMS.ID_Utilisateur_Microsoft = new UtilisateurMicrosoft(UserMSLogin.ID);
                    GenerateAssetPlayer(NewUserMS);
                    if (usersService.AddUtilisateur(NewUserMS))
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
        public ActionResult<Signup> Signup([FromBody] Signup? UserSignup)
        {
            if (UserSignup != null)
            {
                UserSignup.Password = BCrypt.Net.BCrypt.HashPassword(UserSignup.Password);
                var countUsers = usersService.GetAllUtilisateurs().Count(user => (user.Pseudo == UserSignup.Pseudo) || (user.Email == UserSignup.Email));
                if (countUsers > 0)
                {
                    return Conflict();
                }
                else
                {
                    var newUser = new Utilisateur(UserSignup.Pseudo, UserSignup.Nom, UserSignup.Prenom, UserSignup.Email);
                    newUser.ID_Utilisateur_Local = new UtilisateurLocal(UserSignup.Password);
                    GenerateAssetPlayer(newUser);
                    usersService.AddUtilisateur(newUser);
                    return Ok();
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
            var currentToken = HttpContext.User.Identity;
            var claims = ((System.Security.Claims.ClaimsIdentity)currentToken).Claims;
            var authTime = claims.FirstOrDefault(claim => claim.Type == "auth_time");
            return Ok(currentToken.Name + " at " + authTime.Value);
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

        private bool GenerateAssetPlayer(Utilisateur player)
        {
            var worldSelect = worldsService.GetAllMondes().FirstOrDefault();
            if (worldSelect == null)
            {
                worldSelect = new Monde("Terre");
                var newMer = new Mer("Manche");
                newMer.Liste_Iles.Add(new Ile("Île d'Oléron"));
                worldSelect.Liste_Mers.Add(newMer);
            }
            if (player.ID_Monde == null)
            {
                player.ID_Monde = new List<Monde>(1);
            }
            player.ID_Monde.Add(worldSelect);
            var village = new Village(player.Pseudo + " Village");
            if (player.ID_Liste_Villages == null)
            {
                player.ID_Liste_Villages = new List<Village>(1);
            }
            player.ID_Liste_Villages.Add(village);
            var world = worldSelect.Liste_Mers.FirstOrDefault();
            if (world != null)
            {
                var ile = world.Liste_Iles.FirstOrDefault();
                if (ile != null)
                {
                    var listeVillageIles = ile.ID_Village;
                    if (listeVillageIles == null)
                    {
                        listeVillageIles = new List<Village>(1);
                    }
                    listeVillageIles.Add(village);
                    return true;
                }
            }
            return false;
        }
    }
}

