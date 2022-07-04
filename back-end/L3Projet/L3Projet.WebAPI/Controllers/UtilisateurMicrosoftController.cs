using L3Projet.Business.Implementations;
using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtilisateurMicrosoftController : ControllerBase
    {
        private readonly IUtilisateursMicrosoftService utilisateursMicrosoftService;

        public UtilisateurMicrosoftController(IUtilisateursMicrosoftService utilisateursMicrosoftService)
        {
            this.utilisateursMicrosoftService = utilisateursMicrosoftService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<UtilisateurMicrosoft>> GetAll()
        {
            try
            {
                var utilisateurMicrosoft = utilisateursMicrosoftService.GetAllUtilisateursMicrosoft();

                if (utilisateurMicrosoft.Any())
                {
                    return Ok(utilisateurMicrosoft);
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

