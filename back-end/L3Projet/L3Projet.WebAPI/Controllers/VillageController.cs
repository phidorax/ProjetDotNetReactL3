using L3Projet.Business.Implementations;
using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VillageController : ControllerBase
    {
        private readonly IVillagesService villagesService;

        public VillageController(IVillagesService villagesService)
        {
            this.villagesService = villagesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Village>> GetAll()
        {
            try
            {
                var village = villagesService.GetAllVillages();

                if (village.Any())
                {
                    return Ok(village);
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

