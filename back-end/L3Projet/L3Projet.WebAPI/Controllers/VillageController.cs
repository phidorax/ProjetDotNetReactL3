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
    public class VillageController : ControllerBase
    {
        private readonly IVillagesService VillagesService;
        private readonly IUtilisateursService UtilisateursService;

        public VillageController(IVillagesService VillagesService, IUtilisateursService UtilisateursService)
        {
            this.VillagesService = VillagesService;
            this.UtilisateursService = UtilisateursService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Village>> GetAll()
        {
            try
            {
                var Villages = VillagesService.GetAllVillages();

                if (Villages.Any())
                {
                    return Ok(Villages);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{villageid}/ressources")]
        public ActionResult GetRessources([FromRoute] Guid villageid)
        {
            return Ok();
        }


        [HttpPatch("{villageid}/rename")]
        public ActionResult Rename([FromBody] string? newName, [FromRoute] Guid villageid)
        {
            var currentUserToken = HttpContext.User.Identity.Name;
            var currentUser = UtilisateursService.GetAllUtilisateurs().FirstOrDefault(users => users.Pseudo == currentUserToken, null);
            if (VillagesService.RenameVillage(villageid, newName, currentUser))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

