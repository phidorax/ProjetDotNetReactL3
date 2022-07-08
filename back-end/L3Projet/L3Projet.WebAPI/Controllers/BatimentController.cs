using L3Projet.Business.Implementations;
using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BatimentController : ControllerBase
    {
        private readonly IBatimentsService BatimentsService;

        public BatimentController(IBatimentsService BatimentsService)
        {
            this.BatimentsService = BatimentsService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Batiment>> GetAll()
        {
            try
            {
                var batiments = BatimentsService.getAllBatiments();

                if (batiments.Any())
                {
                    return Ok(batiments);
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

