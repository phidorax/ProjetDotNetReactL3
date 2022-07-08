using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MerController : ControllerBase
    {
        private readonly IMersService MersService;

        public MerController(IMersService MersService)
        {
            this.MersService = MersService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Mer>> GetAll()
        {
            try
            {
                var mers = MersService.GetAllMers();

                if (mers.Any())
                {
                    return Ok(mers);
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

