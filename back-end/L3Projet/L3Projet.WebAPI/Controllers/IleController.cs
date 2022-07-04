using L3Projet.Business.Implementations;
using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IleController : ControllerBase
    {
        private readonly IIlesService IlesService;

        public IleController(IIlesService IlesService)
        {
            this.IlesService = IlesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Ile>> GetAll()
        {
            try
            {
                var iles = IlesService.GetAllIles();

                if (iles.Any())
                {
                    return Ok(iles);
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

