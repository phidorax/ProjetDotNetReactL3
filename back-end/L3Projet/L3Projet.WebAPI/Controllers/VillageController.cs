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
                var currentUserToken = HttpContext.User.Identity.Name;
                var currentUser = UtilisateursService.GetAllUtilisateurs().FirstOrDefault(users => users.Pseudo == currentUserToken, null);

                if (currentUser != null)
                {
                    var villagesUser = currentUser.ID_Liste_Villages;
                    if (villagesUser.Count > 0)
                    {
                        return Ok(villagesUser);
                    }
                    else { return NoContent(); }
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{villageid}/ressources")]
        public ActionResult<Dictionary<TypeRessources, ulong>> GetRessources([FromRoute] Guid villageid)
        {
            var currentUserToken = HttpContext.User.Identity.Name;
            var currentUser = UtilisateursService.GetAllUtilisateurs().FirstOrDefault(users => users.Pseudo == currentUserToken, null);
            var ressources = VillagesService.GetRessources(villageid, currentUser);
            if (ressources != null)
            {
                return Ok(ressources);
            }
            else
            {
                return Unauthorized();
            }
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

