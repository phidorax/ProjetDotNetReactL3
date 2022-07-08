using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MondeController : ControllerBase
    {
        private readonly IMondesService mondesService;

        public MondeController(IMondesService mondesService)
        {
            this.mondesService = mondesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Monde>> GetAll()
        {
            try
            {
                var monde = mondesService.GetAllMondes();

                if (monde.Any())
                {
                    return Ok(monde);
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

