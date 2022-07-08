using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IleController : ControllerBase
    {
        private readonly IIlesService IlesService;
        private readonly IUtilisateursService UtilisateursService;
        IleController(IIlesService ilesService, IUtilisateursService utilisateursService)
        {
            IlesService = ilesService;
            UtilisateursService = utilisateursService;
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

        [HttpPatch("{ileid}/newVillage")]
        public ActionResult AddVillage([FromRoute] Guid ileid)
        {
            var ile = IlesService.GetAllIles().FirstOrDefault(i => i.ID_Ile.Equals(ileid));
            if (ile != null)
            {
                var currentUserToken = HttpContext.User.Identity.Name;
                var currentUser = UtilisateursService.GetAllUtilisateurs().FirstOrDefault(users => users.Pseudo == currentUserToken, null);
                if (currentUser != null)
                {
                    var addedVillage = IlesService.AddVillage(ile, currentUser);
                    if (addedVillage) { return Ok(); }
                    else { return Unauthorized(); }
                }
                else
                { return Unauthorized(); }
            }
            else { return NotFound(); }
        }
    }
}

