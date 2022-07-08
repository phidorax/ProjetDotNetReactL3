using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ParametrageController : ControllerBase
    {
        private readonly IParametragesService parametragesService;

        public ParametrageController(IParametragesService parametragesService)
        {
            this.parametragesService = parametragesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Parametrage>> GetAll()
        {
            try
            {
                var param = parametragesService.GetAllParametrages();

                if (param.Any())
                {
                    return Ok(param);
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

