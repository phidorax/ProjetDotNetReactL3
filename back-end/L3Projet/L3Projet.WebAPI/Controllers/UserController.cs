using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        [HttpPost("/login/basic")]
        public ActionResult<IEnumerable<Boolean>> Login([FromBody] BasicLogin? userLogin)
        {
            if (userLogin != null)
            {
                List<BasicLogin> usersBDD = new();
                BasicLogin user1 = new BasicLogin
                {
                    uname = "user1",
                    pass = BCrypt.Net.BCrypt.HashPassword("pass1")
                };
                usersBDD.Add(user1);
                BasicLogin user2 = new BasicLogin
                {
                    uname = "user2",
                    pass = BCrypt.Net.BCrypt.HashPassword("pass2")
                };
                usersBDD.Add(user2);
                BasicLogin? userBdd = usersBDD.FirstOrDefault(user => user.uname == userLogin.uname);
                if (userBdd != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(userLogin.pass, userBdd.pass))
                    {
                        return Ok();
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

        [HttpGet("/users")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                var users = usersService.GetAllUsers();

                if (users.Any())
                {
                    return Ok(users);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

