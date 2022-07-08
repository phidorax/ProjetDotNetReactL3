using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClassementController : ControllerBase
    {
        private readonly IClassementsService classementsService;
        private readonly IUtilisateursService utilisateursService;

        public ClassementController(IClassementsService classementsService, IUtilisateursService utilisateursService)
        {
            this.classementsService = classementsService;
            this.utilisateursService = utilisateursService;
        }

        [AllowAnonymous]
        [HttpGet("global")]
        public ActionResult<Dictionary<string, int>> Global()
        {
            if (utilisateursService.CountUtilisateurs() > 0)
            {
                var dictionary = new Dictionary<string, int>();
                utilisateursService.GetAllUtilisateurs().ToList().ForEach(user => user.ID_Liste_Villages.ToList().ForEach(v => dictionary[user.Pseudo] = v.Score_Village));
                return Ok(dictionary);
            }
            else { return NoContent(); }
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Classement>> GetAll()
        {
            try
            {
                var classement = classementsService.GetAllClassements();

                if (classement.Any())
                {
                    return Ok(classement);
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

