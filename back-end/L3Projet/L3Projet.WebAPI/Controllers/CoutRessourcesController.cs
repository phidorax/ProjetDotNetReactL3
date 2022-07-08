using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CoutRessourcesController : ControllerBase
    {
        private readonly ICoutRessourcesService coutRessourcesService;

        public CoutRessourcesController(ICoutRessourcesService coutRessourcesService)
        {
            this.coutRessourcesService = coutRessourcesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<CoutRessources>> GetAll()
        {
            try
            {
                var coutRessource = coutRessourcesService.GetAllCoutRessources();

                if (coutRessource.Any())
                {
                    return Ok(coutRessource);
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

