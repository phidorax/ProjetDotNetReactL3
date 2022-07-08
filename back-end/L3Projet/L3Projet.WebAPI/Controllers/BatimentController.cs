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
        private readonly IUtilisateursService UtilisateursService;
        private readonly IVillagesService VillagesService;

        public BatimentController(IBatimentsService batimentsService, IUtilisateursService utilisateursService, IVillagesService villagesService)
        {
            BatimentsService = batimentsService;
            UtilisateursService = utilisateursService;
            VillagesService = villagesService;
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


        [HttpPatch("{villageid}/{batimentid}/upgrade")]
        public ActionResult GetRessources([FromRoute] Guid villageid, [FromRoute] Guid batimentid)
        {
            var currentUserToken = HttpContext.User.Identity.Name;
            var currentUser = UtilisateursService.GetAllUtilisateurs().FirstOrDefault(users => users.Pseudo == currentUserToken, null);
            if (currentUser != null)
            {
                var currentVillage = currentUser.ID_Liste_Villages.FirstOrDefault(v => v.ID_Village.Equals(villageid));
                if (currentVillage != null)
                {
                    var currentBatiment = currentVillage.Liste_Batiment.FirstOrDefault(b => b.ID_Batiment.Equals(batimentid));
                    if (currentBatiment != null)
                    {
                        if (VillagesService.UpgradeBatiment(currentVillage.ID_Village, currentBatiment.ID_Batiment))
                        {
                            return Ok();
                        }
                        else
                        {
                            return Unauthorized();
                        }
                    }
                    else { return Unauthorized(); }
                }
                else { return Unauthorized(); }
            }
            else { return Unauthorized(); }
        }
    }
}

