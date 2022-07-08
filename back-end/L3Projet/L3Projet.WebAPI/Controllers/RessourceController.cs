using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RessourceController : ControllerBase
    {
        private readonly IRessoucesService ressoucesService;

        public RessourceController(IRessoucesService ressoucesService)
        {
            this.ressoucesService = ressoucesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Ressources>> GetAll()
        {
            try
            {
                var ressources = ressoucesService.GetAllRessources();

                if (ressources.Any())
                {
                    return Ok(ressources);
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

