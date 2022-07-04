using L3Projet.Business.Implementations;
using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatimentParametrageController : ControllerBase
    {
        private readonly IBatimentParametrageService BatimentParametragesService;

        public BatimentParametrageController(IBatimentParametrageService BatimentParametragesService)
        {
            this.BatimentParametragesService = BatimentParametragesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<BatimentParametrage>> GetAll()
        {
            try
            {
                var batimentParametrages = BatimentParametragesService.GetAllBatimentParametrages();

                if (batimentParametrages.Any())
                {
                    return Ok(batimentParametrages);
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

