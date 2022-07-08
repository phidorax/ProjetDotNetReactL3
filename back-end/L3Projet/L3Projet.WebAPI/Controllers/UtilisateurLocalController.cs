using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UtilisateurLocalController : ControllerBase
    {
        private readonly IUtilisateursLocalService UtilisateursLocalService;

        public UtilisateurLocalController(IUtilisateursLocalService UtilisateursLocalService)
        {
            this.UtilisateursLocalService = UtilisateursLocalService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<UtilisateurLocal>> GetAll()
        {
            try
            {
                var utilisateurLocal = UtilisateursLocalService.GetAllUtilisateursLocal();

                if (utilisateurLocal.Any())
                {
                    return Ok(utilisateurLocal);
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

