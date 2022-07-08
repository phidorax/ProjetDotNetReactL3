using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateursService utilisateurs;

        public UtilisateurController(IUtilisateursService utilisateurs)
        {
            this.utilisateurs = utilisateurs;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Utilisateur>> GetAll()
        {
            try
            {
                var utilisateur = utilisateurs.GetAllUtilisateurs();

                if (utilisateur.Any())
                {
                    return Ok(utilisateur);
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

